import { useEffect, useState } from "react"
import { ContentContainer, MainContainer, StyledTableRow, StyledTableRowHead, TitleContainer } from "./style"
import { voteResultService } from "../../services/voteResultService";
import { ILegislatorStat } from "../../models/LegislatorStat";
import { IBillStat } from "../../models/BillStat";
import { Paper, Table, TableBody, TableCell, TableContainer, TableHead } from "@mui/material";

export const LegisTrack = () => {

  const [legislativeStats, setLegislativeStats] = useState<ILegislatorStat[]>([]);
  const [billStats, setBillStats] = useState<IBillStat[]>([]);

  useEffect(() => {
    const voteResultData = async () => {
      try {
        const legislativeStatsData = await voteResultService.getLegislatorBillSupportStats();
        setLegislativeStats(legislativeStatsData);
        
        const billStatsData = await voteResultService.getBillSupportStats();
        setBillStats(billStatsData);
      } catch (error) {
        console.error(error);
      }
    }
    voteResultData();
  }, []);

  return (
    <MainContainer>
      <TitleContainer>
        <h1>LEGISTRACK</h1>
      </TitleContainer>

      <ContentContainer>
        <div>
          <h2>Legislator Stats</h2>
          <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }}>
              <TableHead>
                <StyledTableRowHead>
                  <TableCell>ID</TableCell>
                  <TableCell>Legislator</TableCell>
                  <TableCell>Supported bills</TableCell>
                  <TableCell>Opposed bills</TableCell>
                </StyledTableRowHead>
              </TableHead>
              <TableBody>
                {
                  legislativeStats?.map(item => (
                    <StyledTableRow key={item.id}>
                      <TableCell>{item.id}</TableCell>
                      <TableCell>{item.legislatorName}</TableCell>
                      <TableCell>{item.support}</TableCell>
                      <TableCell>{item.oppose}</TableCell>
                    </StyledTableRow>
                  ))
                }
              </TableBody>
            </Table>
          </TableContainer>
        </div>

        <div>
          <h2>Bills Stats</h2>
          <TableContainer component={Paper}>
            <Table>
              <TableHead>
                <StyledTableRowHead>
                  <TableCell>ID</TableCell>
                  <TableCell>Legislator</TableCell>
                  <TableCell>Supported bills</TableCell>
                  <TableCell>Opposed bills</TableCell>
                  <TableCell>Primary Sponsor</TableCell>
                </StyledTableRowHead>
              </TableHead>
              <TableBody>
               {
                billStats?.map(item => (
                  <StyledTableRow key={item.id}>
                    <TableCell>{item.id}</TableCell>
                    <TableCell>{item.billName}</TableCell>
                    <TableCell>{item.supporters}</TableCell>
                    <TableCell>{item.opposers}</TableCell>
                    <TableCell>{item.sponsorName}</TableCell>
                  </StyledTableRow>
                ))
               }
              </TableBody>
            </Table>
          </TableContainer>
        </div>
      </ContentContainer>
    </MainContainer>
  )
}