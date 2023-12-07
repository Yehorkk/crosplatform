import { useAuth0 } from "@auth0/auth0-react";
import { useState } from "react";
import { getProtectedLabRun } from "src/services/message.service";

export const useLabResult = (labNum: 1 | 2 | 3) => {
  const [result, setResult] = useState<string>("");
  const { getAccessTokenSilently } = useAuth0();

  const getResult = async (inputPath: string, outputPath: string) => {
    const accessToken = await getAccessTokenSilently();
    const { data, error } = await getProtectedLabRun(accessToken, labNum, inputPath, outputPath);

    if (data) {
      setResult(JSON.stringify(data, null, 2));
    }

    if (error) {
      setResult(JSON.stringify(error, null, 2));
    }
  };

  return { result, getResult };
};
