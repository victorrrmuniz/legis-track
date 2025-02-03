import { TableRow } from "@mui/material";
import styled from "styled-components";

export const MainContainer = styled.div`
  display: flex;
  flex-direction: column;
  gap: 64px;
`

export const TitleContainer = styled.div`
  width: 100%;
  margin: 0 auto;
  background: linear-gradient(135deg, #2e1a6f, #281c54);
  padding: 20px 0;
  display: flex;
  justify-content: center;
  align-items: center;
  box-shadow: 0px 6px 16px rgba(0, 0, 0, 0.2);
  border-bottom: 3px solid #c2a1ff;

  h1 {
    color: #ffffff;
    font-size: 1.75rem;
    font-weight: bold;
    letter-spacing: 2px;
  }
`

export const ContentContainer = styled.div`
  margin: 0 auto;
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 64px;
  margin-bottom: 64px;

  div {
    width: 100%;
    display: flex;
    flex-direction: column;
  }
`

export const StyledTableRow = styled(TableRow)`
  &:nth-of-type(odd) {
    background-color:rgb(246, 246, 255);
  }

  &:last-child td, &:last-child th {
    border: 0;
  }

  &:hover {
    background-color:rgb(229, 229, 253);
  }
`

export const StyledTableRowHead = styled(TableRow)`
  background-color: #281c54;
  
  th {
    color: #dfdfdf;
    font-weight: 600;
    font-size: 1rem;
  }
`