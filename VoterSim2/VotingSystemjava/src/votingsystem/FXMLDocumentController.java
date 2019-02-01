/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package votingsystem;

import java.net.URL;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.chart.BarChart;
import javafx.scene.chart.PieChart;
import javafx.scene.chart.XYChart;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.input.MouseEvent;
import javafx.scene.control.ComboBox;
import javax.swing.JOptionPane;
import javafx.event.EventHandler;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.application.Platform;



/**
 *
 * @author Adam Ebel
 * date 10/9/2018
 */

public class FXMLDocumentController implements Initializable {
    
    // Creating a Array list inorder to keep canidate names
    ArrayList<String> existingCandidates = new ArrayList<String>();
        //Arrays.asList());
        
    //private Map<String, PieChart.Data> barsCreated;

    @FXML
    private Button clickToAdd;

    @FXML
    private Button clickToDelete;

    @FXML
    private BarChart<?, ?> candBarChart;
    
    @FXML
    private TextField addText;
    
    @FXML
    private PieChart candPieChart;
    
    @FXML
    private ComboBox<String> dropDname;
    
    @FXML
    private void quit()
    {
        System.exit(0);
    }
    
    @FXML
    private void resetAll()
    {
        existingCandidates.clear(); // clears the arraylist of the candidate names
        candBarChart.getData().clear(); // clears the datapoints for the bar graph, resetting it
        candPieChart.getData().clear(); // clears the datapoints for the pie graph, resetting it
        dropDname.getItems().clear(); // clears the dropbar, reseting it
    }
    
    private int searchForCandidate(String candName)
    {
        for(int i = 0; i < existingCandidates.size(); i++)
        {
            if(candName.toLowerCase().equals(existingCandidates.get(i).toLowerCase()))
                {
                    return i;
                }
        }
            return -1;
    }
    
    private void addBoth(String candName)
    {
        //start for what was addbar function
        for (XYChart.Series series : candBarChart.getData())
        {
            if (series.getName().equals(candName) )
                return;
        }
        
        XYChart.Series series = new XYChart.Series();
        series.setName(candName);
        
        XYChart.Data<String, Double> bar = new XYChart.Data<String, Double>(candName, 1.0);
        series.getData().add(bar);
        
        candBarChart.getData().add(series);
        
        bar.getNode().setOnMouseClicked(mev -> growBoth(mev, candName) );
 
        PieChart.Data wedge = new PieChart.Data(candName, 1); // starts voter count at a defalt of 1 vote
        
        candPieChart.getData().add(wedge); // adds a wedge to the pie graph
        
        wedge.getNode().setOnMouseClicked(mev -> growBoth(mev, candName));
        addText.clear();
    }
    
    @FXML
    void addCandidate(ActionEvent event) {
        //Button clicked = (Button) event.getSource();
        String candidate = addText.getText();
        
        if(existingCandidates.contains(candidate))
        {
            Alert alert = new Alert(AlertType.INFORMATION);
            alert.setTitle("WHOA, there!");
            alert.setHeaderText(null);
            alert.setContentText("There is already a candidate with that name.");
            alert.showAndWait();
            return;
        }
        existingCandidates.add(candidate); //adds candidate to the array list
        addBoth(candidate); //Adds a Canadidate to the bar graph AND adds a Canadidate to the pie graph
        dropDname.getItems().add(candidate);
    }
    
    @FXML
    void deleteCandidate(ActionEvent event)
            // Deletes a canidate in the dropdown area
    {  
        /*  For clarities sake, I remembered why I had these lines in here.
        The handeler gets reset because otherwise deleteCandidate would have gotten called more than once
        The onAction is triggered on removal of candidate because the value was being changed and that was causing the multiple calls
        EventHandler<ActionEvent> handler = dropDname.getOnAction();
        dropDname.setOnAction(null);
        dropDname.setOnAction(handler); 
        */
        // checks if the drop down selector is holding a null before deleteion
        if (dropDname.getValue() == null ) 
        {
                return;
        }
        String candidate = dropDname.getValue(); // gets the candidate name from the drop down
        dropDname.getItems().remove(candidate); // removes candidate name from the drop down bar
        dropDname.getSelectionModel().clearSelection();

            
        int candidateIndex = searchForCandidate(candidate);
        XYChart.Series series = candBarChart.getData().get(candidateIndex);
        PieChart.Data wedge = candPieChart.getData().get(candidateIndex);
        candBarChart.getData().remove(series); // removes the datapoints for a candidate in the bar graph, bar of graph
        candPieChart.getData().remove(wedge); // removes the datapoints for a candidate in the pie graph, wedge of graph
        existingCandidates.remove(candidateIndex); // removes canidate from the over all existing candidate list
    }    
    
    private void growBoth(MouseEvent e, String candidateName)
    {
        int candidateIndex = searchForCandidate(candidateName);
        XYChart.Series series = candBarChart.getData().get(candidateIndex);
        XYChart.Data bar = (XYChart.Data)series.getData().get(0);
        PieChart.Data wedge = candPieChart.getData().get(candidateIndex);
        bar.setYValue(( (Double) bar.getYValue()) + 1); //Grows the bar in the bar graph for every vote
        wedge.setPieValue(wedge.getPieValue() + 1 ); // Grows the wedge in the pie graph for every vote
    }    
    
    @Override
    public void initialize(URL url, ResourceBundle rb) 
    {    
    }    
}
