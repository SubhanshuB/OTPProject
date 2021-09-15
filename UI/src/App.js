import './App.css';
import  {Button,InputGroup,FormControl,ButtonGroup,Modal,Form}  from 'react-bootstrap';
import { ReactComponent as Logo } from './logo.svg';
import Typewriter from 'typewriter-effect';
import axios from 'axios';
import { useState } from 'react';

function App() {
  const [otp, setOtp] = useState('');
  const [number, setNumber] = useState('');
  const[showMessage, setMessagestate]  = useState(false);
  const[isOTPButtonDisabled,setOTPButton] = useState(false);
  const[isConfirmOTPButtonDisabled,setConfirmOTPButton] = useState(true);
  const[isSignInButtonDisabled,setSignInButton] = useState(true);
  const[isButtonColor,setButtonColor] = useState('');

  const[modalTitle,setmodalTitle] = useState('');
  const[isPopUpOpen,setPopUp] = useState(false);
  const[saveButtonVisibility,setsaveButtonVisibility] = useState(false);

  const [UserEmail, setUserEmail] = useState('');
  const [UserName, setUserName] = useState('');

  const [isUserEditDisabled,setisUserEditDisabled] = useState(false);

  const [successMessage,setSuccessMessage] = useState('');
  const [showsuccessMessage,setShowSuccessMessage] = useState(false);

  const resetAll = () => {
    setOtp('');
    setNumber('');
    window.location.reload();
  };
  

  const logIn = async () => {
     await axios.get('https://localhost:44383/api/users/91' + number)
  .then(response => {
      console.log(response);
      if(response.status !== 200)
      {  
        setmodalTitle("You're not a Registered User, Please Register.");
        setsaveButtonVisibility(true);
        setisUserEditDisabled(false);
        setUserEmail('');
        setUserName('');
      }
      else
      {  
        setmodalTitle("You're a Registered User. Here are your details.");
        setisUserEditDisabled(true);
        setUserEmail(response.data["email"]);
        setUserName(response.data["name"]);
        setsaveButtonVisibility(false);
      }
  })
  .catch(error => {
      alert(error)
  });

    setPopUp(true);
    setShowSuccessMessage(false)
  };

  const addUser = () => {
    if(UserEmail.length === 0 || UserName.length === 0)
    {
      alert("Enter both the required fields");
      return;
    }
    axios.post('https://localhost:44383/api/users', {
      "phoneNumber": "91" + number,
      "name": UserName,
      "email" : UserEmail
    },{
      headers : {
        'Content-Type' : 'application/json'
      }
    })
    .then(response => {
        console.log(response);
        if(response.status === 200)
        {
          setSuccessMessage("Account Added! Please close the pop up now.");
          setShowSuccessMessage(true);
        }
        else
        {
          setSuccessMessage("Something went wrong, Try Again.");
          setShowSuccessMessage(true);
        }
        //setPopUp(false);
    });
  };

  const signIn = () => {
    if(number.length!==10)
      { 
        alert('Phone number should be of 10 digits');
        return;
      }
  setOTPButton(true);
  setTimeout(() => setOTPButton(false), 30000);
  setConfirmOTPButton(false);
    console.log(number);
    axios.get('https://localhost:44383/api/otp/91' + number)
  .then(response => {
      console.log(response);
  })
  .catch(error => {
      alert(error)
  });
  setMessagestate(true);
  console.log("OTP sent");
};

const verifyOtp = () => {
  if(otp.length!==5)
      { 
        alert('Phone number should be of 5 digits');
        return;
      }
    console.log(otp);
    axios.post('https://localhost:44383/api/otp', {
      "phonenumber": "91" + number,
      "otp": otp
    },{
      headers : {
        'Content-Type' : 'application/json'
      }
    })
    .then(response => {
        console.log(response)
        if(response.data === true)
          {
            setButtonColor("#567572FF");
            alert("Correct Otp,Please Sign In");
            setSignInButton(false);
          }
        else
        { 
          setButtonColor("#964F4CFF");
          setConfirmOTPButton(true);
          setOtp('');
          setOTPButton(false);
          alert("Incorrect Otp,Get new OTP");
        }
    });
    
  };


  return (
    <div className='App'>
      <Modal show={isPopUpOpen} onHide={() => setPopUp(false)} >
        <Modal.Header closeButton>
          <Modal.Title>{ modalTitle }</Modal.Title>
        </Modal.Header>
        <Modal.Body>

        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Label>Name</Form.Label>
          <Form.Control type="text" value ={UserName} disabled={isUserEditDisabled} placeholder="Enter Name" onChange = {(event) => setUserName(event.target.value)}/>
        </Form.Group>

        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Label>Email address</Form.Label>
          <Form.Control type="email" value ={UserEmail} disabled={isUserEditDisabled} placeholder="Enter Email" onChange = {(event) => setUserEmail(event.target.value)}/>
        </Form.Group>


        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={ () => setPopUp(false)}>
            Close
          </Button>
          {
            saveButtonVisibility &&
            <Button variant="primary" onClick={() => addUser(false)}>
            Save Changes
            </Button>
          }
          { showsuccessMessage &&
            <h4>{successMessage}</h4>
          }
        </Modal.Footer>
      </Modal>
  <header className='App-header'>
  <div>
          <Logo className ="App-logo"/>
  </div>
    <h2>
    <Typewriter
              options={{
              strings: ['Welcome'],
              autoStart: true,
              loop: true,
              pauseFor:30000
              }}
          />
      </h2>
    <br/>
    <div>
      <InputGroup className='mb-3'>
        <FormControl
          placeholder='Phone Number'
          onChange={(event) => setNumber(event.target.value)}
          value = {number}
        />
          <Button variant='outline-secondary' onClick={signIn} disabled={isOTPButtonDisabled}>Get OTP</Button>
          
      </InputGroup>
      </div>
      {showMessage && <h6 style = {{ color: '#FF8A8A'}}>If OTP sent is of less than 5 digit or you don't receive OTP at all, then click on Get OTP again after 30 sec.</h6>}
    
    <div>
      <InputGroup className='mb-3'>
        <FormControl
          placeholder='Your OTP'
          onChange={(event) => setOtp(event.target.value)}
          value = {otp}
          maxLength = {5}
          minLength = {5}
          disabled={isConfirmOTPButtonDisabled}
        />
        
          <Button variant='outline-secondary' onClick={verifyOtp} style = {{ color : isButtonColor }} disabled={isConfirmOTPButtonDisabled} >Confirm</Button>
        
      </InputGroup>
    </div>
    <div>
      <ButtonGroup>
        <Button variant='outline-primary' disabled={isSignInButtonDisabled} onClick = {logIn}>Sign In</Button>
        <Button variant='outline-warning' onClick={resetAll} >Reset</Button>
      </ButtonGroup>
    </div>
  </header>
</div>
  );
}

export default App;
