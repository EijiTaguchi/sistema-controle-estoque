import { Navigate, Route, Routes } from "react-router-dom";
import AppLayout from "../components/layouts/AppLayout";
import Dashboard from "../pages/Dashboard";
import Fornecedores from "../pages/Fornecedores";
import Login from "../pages/Login";
import Movimentacoes from "../pages/Movimentacoes";
import Perfil from "../pages/Perfil";
import Produtos from "../pages/Produtos";
import Register from "../pages/Register";
import { ProtectedRoute } from "../components/auth/ProtectedRoute";


export default function App() {
  return (
    <Routes>

      {/* Rotas públicas */}
      <Route path="/login" element={<Login />} />
      <Route path="/registrar" element={<Register />} />

      {/* Rotas protegidas */}
      <Route element={<ProtectedRoute />}>
        <Route element={<AppLayout />}>

          <Route
            path="/dashboard"
            element={<Dashboard />}
          />

          <Route
            path="/produtos"
            element={<Produtos />}
          />

          <Route
            path="/fornecedores"
            element={<Fornecedores />}
          />

          <Route
            path="/movimentacoes"
            element={<Movimentacoes />}
          />

          <Route
            path="/perfil"
            element={<Perfil />}
          />

        </Route>
      </Route>

      {/* Rota inicial */}
      <Route
        path="*"
        element={<Navigate to="/dashboard" replace />}
      />

    </Routes>
  );
}