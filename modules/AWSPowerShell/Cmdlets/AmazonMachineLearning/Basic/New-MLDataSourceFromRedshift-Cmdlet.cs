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
    /// Creates a <code>DataSource</code> from <a href="http://aws.amazon.com/redshift/">Amazon
    /// Redshift</a>. A <code>DataSource</code> references data that can be used to perform
    /// either <a>CreateMLModel</a>, <a>CreateEvaluation</a> or <a>CreateBatchPrediction</a>
    /// operations.
    /// 
    ///  
    /// <para><code>CreateDataSourceFromRedshift</code> is an asynchronous operation. In response
    /// to <code>CreateDataSourceFromRedshift</code>, Amazon Machine Learning (Amazon ML)
    /// immediately returns and sets the <code>DataSource</code> status to <code>PENDING</code>.
    /// After the <code>DataSource</code> is created and ready for use, Amazon ML sets the
    /// <code>Status</code> parameter to <code>COMPLETED</code>. <code>DataSource</code> in
    /// <code>COMPLETED</code> or <code>PENDING</code> status can only be used to perform
    /// <a>CreateMLModel</a>, <a>CreateEvaluation</a>, or <a>CreateBatchPrediction</a> operations.
    /// 
    /// </para><para>
    ///  If Amazon ML cannot accept the input source, it sets the <code>Status</code> parameter
    /// to <code>FAILED</code> and includes an error message in the <code>Message</code> attribute
    /// of the <a>GetDataSource</a> operation response. 
    /// </para><para>
    /// The observations should exist in the database hosted on an Amazon Redshift cluster
    /// and should be specified by a <code>SelectSqlQuery</code>. Amazon ML executes <a href="http://docs.aws.amazon.com/redshift/latest/dg/t_Unloading_tables.html">
    /// Unload</a> command in Amazon Redshift to transfer the result set of <code>SelectSqlQuery</code>
    /// to <code>S3StagingLocation.</code></para><para>
    /// After the <code>DataSource</code> is created, it's ready for use in evaluations and
    /// batch predictions. If you plan to use the <code>DataSource</code> to train an <code>MLModel</code>,
    /// the <code>DataSource</code> requires another item -- a recipe. A recipe describes
    /// the observation variables that participate in training an <code>MLModel</code>. A
    /// recipe describes how each input variable will be used in training. Will the variable
    /// be included or excluded from training? Will the variable be manipulated, for example,
    /// combined with another variable or split apart into word combinations? The recipe provides
    /// answers to these questions. For more information, see the Amazon Machine Learning
    /// Developer Guide.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLDataSourceFromRedshift", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateDataSourceFromRedshift operation against Amazon Machine Learning.", Operation = new[] {"CreateDataSourceFromRedshift"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type CreateDataSourceFromRedshiftResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewMLDataSourceFromRedshiftCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataSpec_DatabaseInformation_ClusterIdentifier")]
        public String DatabaseInformation_ClusterIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The compute statistics for a <code>DataSource</code>. The statistics are generated
        /// from the observation data referenced by a <code>DataSource</code>. Amazon ML uses
        /// the statistics internally during <code>MLModel</code> training. This parameter must
        /// be set to <code>true</code> if the <code></code>DataSource<code></code> needs to be
        /// used for <code>MLModel</code> training</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ComputeStatistics { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataSpec_DatabaseInformation_DatabaseName")]
        public String DatabaseInformation_DatabaseName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Describes the splitting specifications for a <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSpec_DataRearrangement { get; set; }
        
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
        public String DataSpec_DataSchema { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Describes the schema location for an Amazon Redshift <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSpec_DataSchemaUri { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A user-supplied ID that uniquely identifies the <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSourceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <code>DataSource</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSourceName { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataSpec_DatabaseCredentials_Password")]
        public String DatabaseCredentials_Password { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A fully specified role Amazon Resource Name (ARN). Amazon ML assumes the role on behalf
        /// of the user to create the following: </para><para><ul><li><para>A security group to allow Amazon ML to execute the <code>SelectSqlQuery</code> query
        /// on an Amazon Redshift cluster</para></li><li><para>An Amazon S3 bucket policy to grant Amazon ML read/write permissions on the <code>S3StagingLocation</code></para></li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RoleARN { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Describes an Amazon S3 location to store the result set of the <code>SelectSqlQuery</code>
        /// query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSpec_S3StagingLocation { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Describes the SQL Query to execute on an Amazon Redshift database for an Amazon Redshift
        /// <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSpec_SelectSqlQuery { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataSpec_DatabaseCredentials_Username")]
        public String DatabaseCredentials_Username { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            if (ParameterWasBound("ComputeStatistics"))
                context.ComputeStatistics = this.ComputeStatistics;
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
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateDataSourceFromRedshiftRequest();
            
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
            request.DataSpec = new RedshiftDataSpec();
            String requestDataSpec_dataSpec_DataRearrangement = null;
            if (cmdletContext.DataSpec_DataRearrangement != null)
            {
                requestDataSpec_dataSpec_DataRearrangement = cmdletContext.DataSpec_DataRearrangement;
            }
            if (requestDataSpec_dataSpec_DataRearrangement != null)
            {
                request.DataSpec.DataRearrangement = requestDataSpec_dataSpec_DataRearrangement;
                requestDataSpecIsNull = false;
            }
            String requestDataSpec_dataSpec_DataSchema = null;
            if (cmdletContext.DataSpec_DataSchema != null)
            {
                requestDataSpec_dataSpec_DataSchema = cmdletContext.DataSpec_DataSchema;
            }
            if (requestDataSpec_dataSpec_DataSchema != null)
            {
                request.DataSpec.DataSchema = requestDataSpec_dataSpec_DataSchema;
                requestDataSpecIsNull = false;
            }
            String requestDataSpec_dataSpec_DataSchemaUri = null;
            if (cmdletContext.DataSpec_DataSchemaUri != null)
            {
                requestDataSpec_dataSpec_DataSchemaUri = cmdletContext.DataSpec_DataSchemaUri;
            }
            if (requestDataSpec_dataSpec_DataSchemaUri != null)
            {
                request.DataSpec.DataSchemaUri = requestDataSpec_dataSpec_DataSchemaUri;
                requestDataSpecIsNull = false;
            }
            String requestDataSpec_dataSpec_S3StagingLocation = null;
            if (cmdletContext.DataSpec_S3StagingLocation != null)
            {
                requestDataSpec_dataSpec_S3StagingLocation = cmdletContext.DataSpec_S3StagingLocation;
            }
            if (requestDataSpec_dataSpec_S3StagingLocation != null)
            {
                request.DataSpec.S3StagingLocation = requestDataSpec_dataSpec_S3StagingLocation;
                requestDataSpecIsNull = false;
            }
            String requestDataSpec_dataSpec_SelectSqlQuery = null;
            if (cmdletContext.DataSpec_SelectSqlQuery != null)
            {
                requestDataSpec_dataSpec_SelectSqlQuery = cmdletContext.DataSpec_SelectSqlQuery;
            }
            if (requestDataSpec_dataSpec_SelectSqlQuery != null)
            {
                request.DataSpec.SelectSqlQuery = requestDataSpec_dataSpec_SelectSqlQuery;
                requestDataSpecIsNull = false;
            }
            RedshiftDatabaseCredentials requestDataSpec_dataSpec_DatabaseCredentials = null;
            
             // populate DatabaseCredentials
            bool requestDataSpec_dataSpec_DatabaseCredentialsIsNull = true;
            requestDataSpec_dataSpec_DatabaseCredentials = new RedshiftDatabaseCredentials();
            String requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password = null;
            if (cmdletContext.DataSpec_DatabaseCredentials_Password != null)
            {
                requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password = cmdletContext.DataSpec_DatabaseCredentials_Password;
            }
            if (requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password != null)
            {
                requestDataSpec_dataSpec_DatabaseCredentials.Password = requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Password;
                requestDataSpec_dataSpec_DatabaseCredentialsIsNull = false;
            }
            String requestDataSpec_dataSpec_DatabaseCredentials_databaseCredentials_Username = null;
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
            RedshiftDatabase requestDataSpec_dataSpec_DatabaseInformation = null;
            
             // populate DatabaseInformation
            bool requestDataSpec_dataSpec_DatabaseInformationIsNull = true;
            requestDataSpec_dataSpec_DatabaseInformation = new RedshiftDatabase();
            String requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier = null;
            if (cmdletContext.DataSpec_DatabaseInformation_ClusterIdentifier != null)
            {
                requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier = cmdletContext.DataSpec_DatabaseInformation_ClusterIdentifier;
            }
            if (requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier != null)
            {
                requestDataSpec_dataSpec_DatabaseInformation.ClusterIdentifier = requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_ClusterIdentifier;
                requestDataSpec_dataSpec_DatabaseInformationIsNull = false;
            }
            String requestDataSpec_dataSpec_DatabaseInformation_databaseInformation_DatabaseName = null;
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
                var response = client.CreateDataSourceFromRedshift(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Boolean? ComputeStatistics { get; set; }
            public String DataSourceId { get; set; }
            public String DataSourceName { get; set; }
            public String DataSpec_DatabaseCredentials_Password { get; set; }
            public String DataSpec_DatabaseCredentials_Username { get; set; }
            public String DataSpec_DatabaseInformation_ClusterIdentifier { get; set; }
            public String DataSpec_DatabaseInformation_DatabaseName { get; set; }
            public String DataSpec_DataRearrangement { get; set; }
            public String DataSpec_DataSchema { get; set; }
            public String DataSpec_DataSchemaUri { get; set; }
            public String DataSpec_S3StagingLocation { get; set; }
            public String DataSpec_SelectSqlQuery { get; set; }
            public String RoleARN { get; set; }
        }
        
    }
}
