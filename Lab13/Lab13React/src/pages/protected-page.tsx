import { useAuth0 } from "@auth0/auth0-react";
import React, { useEffect, useState } from "react";
import { CodeSnippet } from "../components/code-snippet";
import { PageLayout } from "../components/page-layout";
import { getProtectedResource } from "../services/message.service";

export const ProtectedPage: React.FC = () => {
  const [message, setMessage] = useState<string>("");

  const { getAccessTokenSilently } = useAuth0();

  useEffect(() => {
    let isMounted = true;

    const getMessage = async () => {
      const accessToken = await getAccessTokenSilently();
      const { data, error } = await getProtectedResource(accessToken);

      if (!isMounted) {
        return;
      }

      if (data) {
        setMessage(JSON.stringify(data, null, 2));
      }

      if (error) {
        setMessage(JSON.stringify(error, null, 2));
      }
    };

    getMessage();

    return () => {
      isMounted = false;
    };
  }, [getAccessTokenSilently]);

  return (
    <PageLayout>
      <div className="content-layout">
        <h1
          id="page-title"
          className="content__title"
        >
          Захищена сторінка
        </h1>
        <div className="content__body">
          <p id="page-description">
            <span>
              На цій сторінці ви можете побачити інформацію з АПІ, яка вже є захищеною за допомогою
              перевірки токену користувача.
            </span>
          </p>
          <CodeSnippet
            title="Захищене повідомлення з АПІ:"
            code={message}
          />
        </div>
      </div>
    </PageLayout>
  );
};
