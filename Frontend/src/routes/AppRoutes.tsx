import { Navigate, Route, Routes } from "react-router-dom";
import AppLayout from "../components/layouts/AppLayout";
import Dashboard from "../pages/Dashboard";
import Fornecedores from "../pages/Fornecedores";
import Login from "../pages/Login";
import Movimentacoes from "../pages/Movimentacoes";
import Perfil from "../pages/Perfil";
import Produtos from "../pages/Produtos";
import Register from "../pages/Register";


export const AppRoutes = () => {
    return (
        <Routes>
            <Route path="/" element={<Login />} />
            <Route path="/register" element={<Register />} />

            <Route element={<AppLayout />}>
                <Route path="/dashboard" element={<Dashboard />} />
                <Route path="/produtos" element={<Produtos />} />
                <Route path="/fornecedores" element={<Fornecedores />} />
                <Route path="/movimentacoes" element={<Movimentacoes />} />
                <Route path="/perfil" element={<Perfil />} />
            </Route>

            <Route
                path="*" 
                element={<Navigate to="/" replace />}
            />
        </Routes>
    )
}