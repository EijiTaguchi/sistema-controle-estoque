import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";

import { Button } from "../../components/ui/button";
import { Input } from "../../components/ui/input";
import { Label } from "../../components/ui/label";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "../../components/ui/card";

import { register as registerRequest } from "../../api/auth";

export default function Register() {
  const navigate = useNavigate();

  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  async function handleSubmit(event: React.FormEvent) {
    event.preventDefault();

    setError("");
    setLoading(true);

    try {
      await registerRequest({
        userName,
        email,
        password,
      });

      navigate("/login");
    } catch (error) {
      setError("Não foi possível criar a conta.");
    } finally {
      setLoading(false);
    }
  }

  return (
    <div className="flex min-h-screen items-center justify-center bg-muted/20 p-6">
      <Card className="w-full max-w-md">
        <CardHeader>
          <CardTitle className="text-xl text-center">Criar conta</CardTitle>

          <CardDescription className="text-md text-center mb-2">
            Cadastre-se para acessar o sistema.
          </CardDescription>
        </CardHeader>

        <CardContent>
          <form onSubmit={handleSubmit} className="space-y-4">

            {error && (
              <p className="text-sm text-destructive">
                {error}
              </p>
            )}

            <div className="space-y-2">
              <Label htmlFor="userName">
                Nome de usuário
              </Label>

              <Input
                id="userName"
                value={userName}
                onChange={(event) =>
                  setUserName(event.target.value)
                }
                required
              />
            </div>

            <div className="space-y-2">
              <Label htmlFor="email">
                E-mail
              </Label>

              <Input
                id="email"
                type="email"
                value={email}
                onChange={(event) =>
                  setEmail(event.target.value)
                }
                required
              />
            </div>

            <div className="space-y-2">
              <Label htmlFor="password">
                Senha
              </Label>

              <Input
                id="password"
                type="password"
                value={password}
                onChange={(event) =>
                  setPassword(event.target.value)
                }
                required
              />
            </div>

            <Button
              type="submit"
              className="w-full"
              disabled={loading}
            >
              {loading ? "Criando..." : "Criar conta"}
            </Button>

            <p className="text-center text-sm text-muted-foreground">
              Já possui uma conta?{" "}
              <Link
                to="/login"
                className="font-medium text-primary hover:underline"
              >
                Entrar
              </Link>
            </p>

          </form>
        </CardContent>
      </Card>
    </div>
  );
}