/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Creates a <code>DataSource</code> from a database hosted on an Amazon Redshift cluster.
    /// A <code>DataSource</code> references data that can be used to perform either <code>CreateMLModel</code>,
    /// <code>CreateEvaluation</code>, or <code>CreateBatchPrediction</code> operations.
    /// 
    ///  
    /// <para><code>CreateDataSourceFromRedshift</code> is an asynchronous operation. In response
    /// to <code>CreateDataSourceFromRedshift</code>, Amazon Machine Learning (Amazon ML)
    /// immediately returns and sets the <code>DataSource</code> status to <code>PENDING</code>.
    /// After the <code>DataSource</code> is created and ready for use, Amazon ML sets the
    /// <code>Status</code> parameter to <code>COMPLETED</code>. <code>DataSource</code> in
    /// <code>COMPLETED</code> or <code>PENDING</code> states can be used to perform only
    /// <code>CreateMLModel</code>, <code>CreateEvaluation</code>, or <code>CreateBatchPrediction</code>
    /// operations. 
    /// </para><para>
    ///  If Amazon ML can't accept the input source, it sets the <code>Status</code> parameter
    /// to <code>FAILED</code> and includes an error message in the <code>Message</code> attribute
    /// of the <code>GetDataSource</code> operation response. 
    /// </para><para>
    /// The observations should be contained in the database hosted on an Amazon Redshift
    /// cluster and should be specified by a <code>SelectSqlQuery</code> query. Amazon ML
    /// executes an <code>Unload</code> command in Amazon Redshift to transfer the result
    /// set of the <code>SelectSqlQuery</code> query to <code>S3StagingLocation</code>.
    /// </para><para>
    /// After the <code>DataSource</code> has been created, it's ready for use in evaluations
    /// and batch predictions. If you plan to use the <code>DataSource</code> to train an
    /// <code>MLModel</code>, the <code>DataSource</code> also requires a recipe. A recipe
    /// describes how each input variable will be used in training an <code>MLModel</code>.
    /// Will the variable be included or excluded from training? Will the variable be manipulated;
    /// for example, will it be combined with another variable or will it be split apart into
    /// word combinations? The recipe provides answers to these questions.
    /// </para><para>
    /// You can't change an existing datasource, but you can copy and modify the settings
    /// from an existing Amazon Redshift datasource to create a new datasource. To do so,
    /// call <code>GetDataSource</code> for an existing datasource and copy the values to
    /// a <code>CreateDataSource</code> call. Change the settings that you want to change
    /// and make sure that all required fields have the appropriate values.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLDataSourceFromRedshift", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateDataSourceFromRedshift operation against Amazon Machine Learning.", Operation = new[] {"CreateDataSourceFromRedshift"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMLDataSourceFromRedshiftCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        #region Parameter DatabaseInformation_ClusterIdentifier
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataSpec_DatabaseInformation_ClusterIdentifier")]
        public System.String DatabaseInformation_ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ComputeStatistic
        /// <summary>
        /// <para>
        /// <para>The compute statistics for a <code>DataSource</code>. The statistics are generated
        /// from the observation data referenced by a <code>DataSource</code>. Amazon ML uses
        /// the statistics internally during <code>MLModel</code> training. This parameter must
        /// be set to <code>true</code> if the <code>DataSource</code> needs to be used for <code>MLModel</code>
        /// training.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputeStatistics")]
        public System.Boolean ComputeStatistic { get; set; }
        #endregion
        
        #region Parameter DatabaseInformation_DatabaseName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataSpec_DatabaseInformation_DatabaseName")]
        public System.String DatabaseInformation_DatabaseName { get; set; }
        #endregion
        
        #region Parameter DataSpec_DataRearrangement
        /// <summary>
        /// <para>
        /// <para>A JSON string that represents the splitting and rearrangement processing to be applied
        /// to a <code>DataSource</code>. If the <code>DataRearrangement</code> parameter is not
        /// provided, all of the input data is used to create the <code>Datasource</code>.</para><para>There are multiple parameters that control what data is used to create a datasource:</para><ul><li><para><b><code>percentBegin</code></b></para><para>Use <code>percentBegin</code> to indicate the beginning of the range of the data used
        /// to create the Datasource. If you do not include <code>percentBegin</code> and <code>percentEnd</code>,
        /// Amazon ML includes all of the data when creating the datasource.</para></li><li><para><b><code>percentEnd</code></b></para><para>Use <code>percentEnd</code> to indicate the end of the range of the data used to create
        /// the Datasource. If you do not include <code>percentBegin</code> and <code>percentEnd</code>,
        /// Amazon ML includes all of the data when creating the datasource.</para></li><li><para><b><code>complement</code></b></para><para>The <code>complement</code> parameter instructs Amazon ML to use the data that is
        /// not included in the range of <code>percentBegin</code> to <code>percentEnd</code>
        /// to create a datasource. The <code>complement</code> parameter is useful if you need
        /// to create complementary datasources for training and evaluation. To create a complementary
        /// datasource, use the same values for <code>percentBegin</code> and <code>percentEnd</code>,
        /// along with the <code>complement</code> parameter.</para><para>For example, the following two datasources do not share any data, and can be used
        /// to train and evaluate a model. The first datasource has 25 percent of the data, and
        /// the second one has 75 percent of the data.</para><para>Datasource for evaluation: <code>{"splitting":{"percentBegin":0, "percentEnd":25}}</code></para><para>Datasource for training: <code>{"splitting":{"percentBegin":0, "percentEnd":25, "complement":"true"}}</code></para></li><li><para><b><code>strategy</code></b></para><para>To change how Amazon ML splits the data for a datasource, use the <code>strategy</code>
        /// parameter.</para><para>The default value for the <code>strategy</code> parameter is <code>sequential</code>,
        /// meaning that Amazon ML takes all of the data records between the <code>percentBegin</code>
        /// and <code>percentEnd</code> parameters for the datasource, in the order that the records
        /// appear in the input data.</para><para>The following two <code>DataRearrangement</code> lines are examples of sequentially
        /// ordered training and evaluation datasources:</para><para>Datasource for evaluation: <code>{"splitting":{"percentBegin":70, "percentEnd":100,
        /// "strategy":"sequential"}}</code></para><para>Datasource for training: <code>{"splitting":{"percentBegin":70, "percentEnd":100,
        /// "strategy":"sequential", "complement":"true"}}</code></para><para>To randomly split the input data into the proportions indicated by the percentBegin
        /// and percentEnd parameters, set the <code>strategy</code> parameter to <code>random</code>
        /// and provide a string that is used as the seed value for the random data splitting
        /// (for example, you can use the S3 path to your data as the random seed string). If
        /// you choose the random split strategy, Amazon ML assigns each row of data a pseudo-random
        /// number between 0 and 100, and then selects the rows that have an assigned number between
        /// <code>percentBegin</code> and <code>percentEnd</code>. Pseudo-random numbers are assigned
        /// using both the input seed string value and the byte offset as a seed, so changing
        /// the data results in a different split. Any existing ordering is preserved. The random
        /// splitting strategy ensures that variables in the training and evaluation data are
        /// distributed similarly. It is useful in the cases where the input data may have an
        /// implicit sort order, which would otherwise result in training and evaluation datasources
        /// containing non-similar data records.</para><para>The following two <code>DataRearrangement</code> lines are examples of non-sequentially
        /// ordered training and evaluation datasources:</para><para>Datasource for evaluation: <code>{"splitting":{"percentBegin":70, "percentEnd":100,
        /// "strategy":"random", "randomSeed"="s3://my_s3_path/bucket/file.csv"}}</code></para><para>Datasource for training: <code>{"splitting":{"percentBegin":70, "percentEnd":100,
        /// "strategy":"random", "randomSeed"="s3://my_s3_path/bucket/file.csv", "complement":"true"}}</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DataSpec_DataRearrangement { get; set; }
        #endregion
        
        #region Parameter DataSpec_DataSchema
        /// <summary>
        /// <para>
        /// <para>A JSON string that represents the schema for an Amazon Redshift <code>DataSource</code>.
        /// The <code>DataSchema</code> defines the structure of the observation data in the data
        /// file(s) referenced in the <code>DataSource</code>.</para><para>A <code>DataSchema</code> is not required if you specify a <code>DataSchemaUri</code>.</para><para>Define your <code>DataSchema</code> as a series of key-value pairs. <code>attributes</code>
        /// and <code>excludedVariableNames</code> have an array of key-value pairs for their
        /// value. Use the following format to define your <code>DataSchema</code>.</para><para>{ "version": "1.0",</para><para> "recordAnnotationFieldName": "F1",</para><para> "recordWeightFieldName": "F2",</para><para> "targetFieldName": "F3",</para><para> "dataFormat": "CSV",</para><para> "dataFileContainsHeader": true,</para><para> "attributes": [</para><para> { "fieldName": "F1", "fieldType": "TEXT" }, { "fieldName": "F2", "fieldType": "NUMERIC"
        /// }, { "fieldName": "F3", "fieldType": "CATEGORICAL" }, { "fieldName": "F4", "fieldType":
        /// "NUMERIC" }, { "fieldName": "F5", "fieldType": "CATEGORICAL" }, { "fieldName": "F6",
        /// "fieldType": "TEXT" }, { "fieldName": "F7", "fieldType": "WEIGHTED_INT_SEQUENCE" },
        /// { "fieldName": "F8", "fieldType": "WEIGHTED_STRING_SEQUENCE" } ],</para><para> "excludedVariableNames": [ "F6" ] } </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DataSpec_DataSchema { get; set; }
        #endregion
        
        #region Parameter DataSpec_DataSchemaUri
        /// <summary>
        /// <para>
        /// <para>Describes the schema location for an Amazon Redshift <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DataSpec_DataSchemaUri { get; set; }
        #endregion
        
        #region Parameter DataSourceId
        /// <summary>
        /// <para>
        /// <para>A user-supplied ID that uniquely identifies the <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DataSourceId { get; set; }
        #endregion
        
        #region Parameter DataSourceName
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <code>DataSource</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DataSourceName { get; set; }
        #endregion
        
        #region Parameter DatabaseCredentials_Password
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataSpec_DatabaseCredentials_Password")]
        public System.String DatabaseCredentials_Password { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>A fully specified role Amazon Resource Name (ARN). Amazon ML assumes the role on behalf
        /// of the user to create the following: </para><para><ul><li><para>A security group to allow Amazon ML to execute the <code>SelectSqlQuery</code> query
        /// on an Amazon Redshift cluster</para></li><li><para>An Amazon S3 bucket policy to grant Amazon ML read/write permissions on the <code>S3StagingLocation</code></para></li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter DataSpec_S3StagingLocation
        /// <summary>
        /// <para>
        /// <para>Describes an Amazon S3 location to store the result set of the <code>SelectSqlQuery</code>
        /// query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DataSpec_S3StagingLocation { get; set; }
        #endregion
        
        #region Parameter DataSpec_SelectSqlQuery
        /// <summary>
        /// <para>
        /// <para>Describes the SQL Query to execute on an Amazon Redshift database for an Amazon Redshift
        /// <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DataSpec_SelectSqlQuery { get; set; }
        #endregion
        
        #region Parameter DatabaseCredentials_Username
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataSpec_DatabaseCredentials_Username")]
        public System.String DatabaseCredentials_Username { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DataSourceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLDataSourceFromRedshift (CreateDataSourceFromRedshift)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("ComputeStatistic"))
                context.ComputeStatistics = this.ComputeStatistic;
            context.DataSourceId = this.DataSourceId;
            context.DataSourceName = this.DataSourceName;
            context.DataSpec_DatabaseCredentials_Password = this.DatabaseCredentials_Password;
            context.DataSpec_DatabaseCredentials_Username = this.DatabaseCredentials_Username;
            context.DataSpec_DatabaseInformation_ClusterIdentifier = this.DatabaseInformation_ClusterIdentifier;
            context.DataSpec_DatabaseInformation_DatabaseName = this.DatabaseInformation_DatabaseName;
            context.DataSpec_DataRearrangement = this.DataSpec_DataRearrangement;
            context.DataSpec_DataSchema = this.DataSpec_DataSchema;
            context.DataSpec_DataSchemaUri = this.DataSpec_DataSchemaUri;
            context.DataSpec_S3StagingLocation = this.DataSpec_S3StagingLocation;
            context.DataSpec_SelectSqlQuery = this.DataSpec_SelectSqlQuery;
            context.RoleARN = this.RoleARN;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftRequest();
            
            if (cmdletContext.ComputeStatistics != null)
            {
                request.ComputeStatistics = cmdletContext.ComputeStatistics.Value;
            }
            if (cmdletContext.DataSourceId != null)
            {
                request.DataSourceId = cmdletContext.DataSourceId;
            }
            if (cmdletContext.DataSourceName != null)
            {
                request.DataSourceName = cmdletContext.DataSourceName;
            }
            
             // populate DataSpec
            bool requestDataSpecIsNull = true;
            request.DataSpec = new Amazon.MachineLearning.Model.RedshiftDataSpec();
            System.String requestDataSpec_dataSpec_DataRearrangement = null;
            if (cmdletContext.DataSpec_DataRearrangement != null)
            {
                requestDataSpec_dataSpec_DataRearrangement = cmdletContext.DataSpec_DataRearrangement;
            }
            if (requestDataSpec_dataSpec_DataRearrangement != null)
            {
                request.DataSpec.DataRearrangement = requestDataSpec_dataSpec_DataRearrangement;
                requestDataSpecIsNull = false;
            }
            System.String requestDataSpec_dataSpec_DataSchema = null;
            if (cmdletContext.DataSpec_DataSchema != null)
            {
                requestDataSpec_dataSpec_DataSchema = cmdletContext.DataSpec_DataSchema;
            }
            if (requestDataSpec_dataSpec_DataSchema != null)
            {
                request.DataSpec.DataSchema = requestDataSpec_dataSpec_DataSchema;
                requestDataSpecIsNull = false;
            }
            System.String requestDataSpec_dataSpec_DataSchemaUri = null;
            if (cmdletContext.DataSpec_DataSchemaUri != null)
            {
                requestDataSpec_dataSpec_DataSchemaUri = cmdletContext.DataSpec_DataSchemaUri;
            }
            if (requestDataSpec_dataSpec_DataSchemaUri != null)
            {
                request.DataSpec.DataSchemaUri = requestDataSpec_dataSpec_DataSchemaUri;
                requestDataSpecIsNull = false;
            }
            System.String requestDataSpec_dataSpec_S3StagingLocation = null;
            if (cmdletContext.DataSpec_S3StagingLocation != null)
            {
                requestDataSpec_dataSpec_S3StagingLocation = cmdletContext.DataSpec_S3StagingLocation;
            }
            if (requestDataSpec_dataSpec_S3StagingLocation != null)
            {
                request.DataSpec.S3StagingLocation = requestDataSpec_dataSpec_S3StagingLocation;
                requestDataSpecIsNull = false;
            }
            System.String requestDataSpec_dataSpec_SelectSqlQuery = null;
            if (cmdletContext.DataSpec_SelectSqlQuery != null)
            {
                requestDataSpec_dataSpec_SelectSqlQuery = cmdletContext.DataSpec_SelectSqlQuery;
            }
            if (requestDataSpec_dataSpec_SelectSqlQuery != null)
            {
                request.DataSpec.SelectSqlQuery = requestDataSpec_dataSpec_SelectSqlQuery;
                requestDataSpecIsNull = false;
            }
            Amazon.MachineLearning.Model.RedshiftDatabaseCredentials requestDataSpec_dataSpec_DatabaseCredentials = null;
            
             // populate DatabaseCredentials
            bool requestDataSpec_dataSpec_DatabaseCredentialsIsNull = true;
            requestDataSpec_dataSpec_DatabaseCredentials = new Amazon.MachineLearning.Model.RedshiftDatabaseCredentials();
            System.String requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password = null;
            if (cmdletContext.DataSpec_DatabaseCredentials_Password != null)
            {
                requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password = cmdletContext.DataSpec_DatabaseCredentials_Password;
            }
            if (requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password != null)
            {
                requestDataSpec_dataSpec_DatabaseCredentials.Password = requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password;
                requestDataSpec_dataSpec_DatabaseCredentialsIsNull = false;
            }
            System.String requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Username = null;
            if (cmdletContext.DataSpec_DatabaseCredentials_Username != null)
            {
                requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Username = cmdletContext.DataSpec_DatabaseCredentials_Username;
            }
            if (requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Username != null)
            {
                requestDataSpec_dataSpec_DatabaseCredentials.Username = requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Username;
                requestDataSpec_dataSpec_DatabaseCredentialsIsNull = false;
            }
             // determine if requestDataSpec_dataSpec_DatabaseCredentials should be set to null
            if (requestDataSpec_dataSpec_DatabaseCredentialsIsNull)
            {
                requestDataSpec_dataSpec_DatabaseCredentials = null;
            }
            if (requestDataSpec_dataSpec_DatabaseCredentials != null)
            {
                request.DataSpec.DatabaseCredentials = requestDataSpec_dataSpec_DatabaseCredentials;
                requestDataSpecIsNull = false;
            }
            Amazon.MachineLearning.Model.RedshiftDatabase requestDataSpec_dataSpec_DatabaseInformation = null;
            
             // populate DatabaseInformation
            bool requestDataSpec_dataSpec_DatabaseInformationIsNull = true;
            requestDataSpec_dataSpec_DatabaseInformation = new Amazon.MachineLearning.Model.RedshiftDatabase();
            System.String requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier = null;
            if (cmdletContext.DataSpec_DatabaseInformation_ClusterIdentifier != null)
            {
                requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier = cmdletContext.DataSpec_DatabaseInformation_ClusterIdentifier;
            }
            if (requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier != null)
            {
                requestDataSpec_dataSpec_DatabaseInformation.ClusterIdentifier = requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier;
                requestDataSpec_dataSpec_DatabaseInformationIsNull = false;
            }
            System.String requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_DatabaseName = null;
            if (cmdletContext.DataSpec_DatabaseInformation_DatabaseName != null)
            {
                requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_DatabaseName = cmdletContext.DataSpec_DatabaseInformation_DatabaseName;
            }
            if (requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_DatabaseName != null)
            {
                requestDataSpec_dataSpec_DatabaseInformation.DatabaseName = requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_DatabaseName;
                requestDataSpec_dataSpec_DatabaseInformationIsNull = false;
            }
             // determine if requestDataSpec_dataSpec_DatabaseInformation should be set to null
            if (requestDataSpec_dataSpec_DatabaseInformationIsNull)
            {
                requestDataSpec_dataSpec_DatabaseInformation = null;
            }
            if (requestDataSpec_dataSpec_DatabaseInformation != null)
            {
                request.DataSpec.DatabaseInformation = requestDataSpec_dataSpec_DatabaseInformation;
                requestDataSpecIsNull = false;
            }
             // determine if request.DataSpec should be set to null
            if (requestDataSpecIsNull)
            {
                request.DataSpec = null;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DataSourceId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.CreateDataSourceFromRedshiftRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "CreateDataSourceFromRedshift");
            #if DESKTOP
            return client.CreateDataSourceFromRedshift(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateDataSourceFromRedshiftAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Boolean? ComputeStatistics { get; set; }
            public System.String DataSourceId { get; set; }
            public System.String DataSourceName { get; set; }
            public System.String DataSpec_DatabaseCredentials_Password { get; set; }
            public System.String DataSpec_DatabaseCredentials_Username { get; set; }
            public System.String DataSpec_DatabaseInformation_ClusterIdentifier { get; set; }
            public System.String DataSpec_DatabaseInformation_DatabaseName { get; set; }
            public System.String DataSpec_DataRearrangement { get; set; }
            public System.String DataSpec_DataSchema { get; set; }
            public System.String DataSpec_DataSchemaUri { get; set; }
            public System.String DataSpec_S3StagingLocation { get; set; }
            public System.String DataSpec_SelectSqlQuery { get; set; }
            public System.String RoleARN { get; set; }
        }
        
    }
}
