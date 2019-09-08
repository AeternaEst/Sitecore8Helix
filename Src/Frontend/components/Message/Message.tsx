import * as React from "react";

export interface MessageProps {
  message: string;
}

const Message = (props: MessageProps) => {
  const { message } = props;
  return (
    <div className="message">
      <span className="message__text">{message}</span>
    </div>
  );
};

export default Message;
