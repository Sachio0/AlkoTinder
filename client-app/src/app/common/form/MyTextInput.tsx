import React from 'react';
import { Form, Label } from 'semantic-ui-react';

interface Props {
    placeholder: string;
    name: string;
    label?: string;
}
//TO DO check and end
export default function MyTextInput(props: Props){
    const[filed, meta] = useFiled(props.name);
    return(
       <Form.Field error={meta.touched && !!meta.error}>
           <label>{props.label}</label>
           <input{...filed}{...props}/>
           {meta.touched && meta.error ? (
           <Label basic color='red'>{meta.error}</Label>
           ): null}
       </Form.Field> 
    )
}
