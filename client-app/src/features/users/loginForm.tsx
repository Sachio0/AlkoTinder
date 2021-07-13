import React from 'react';

export default function LoginForm() {
    return(
        <Formik
        InitialValues={{emiail: '', password: ''}}
        onSubmit={values => console.log(values)}
        >
        {(hanldeSubmit) => (
            <Form className='ui form' onSubmit={hanldeSubmit} autoComplete='off'>
                <MyTextInput name='email' placeholder = 'Email'/>
                <MyTextInput name='password' placeholder = 'Password' type='password'/>


            </Form>
        )}
        </Formik>
    )
}