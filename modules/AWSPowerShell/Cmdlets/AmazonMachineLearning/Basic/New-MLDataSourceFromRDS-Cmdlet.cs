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
    /// Creates a <code>DataSource</code> object from an <a href="http://aws.amazon.com/rds/">
    /// Amazon Relational Database Service</a> (Amazon RDS). A <code>DataSource</code> references
    /// data that can be used to perform <a>CreateMLModel</a>, <a>CreateEvaluation</a>, or
    /// <a>CreateBatchPrediction</a> operations.
    /// 
    ///  
    /// <para><code>CreateDataSourceFromRDS</code> is an asynchronous operation. In response to
    /// <code>CreateDataSourceFromRDS</code>, Amazon Machine Learning (Amazon ML) immediately
    /// returns and sets the <code>DataSource</code> status to <code>PENDING</code>. After
    /// the <code>DataSource</code> is created and ready for use, Amazon ML sets the <code>Status</code>
    /// parameter to <code>COMPLETED</code>. <code>DataSource</code> in <code>COMPLETED</code>
    /// or <code>PENDING</code> status can only be used to perform <a>CreateMLModel</a>, <a>CreateEvaluation</a>,
    /// or <a>CreateBatchPrediction</a> operations. 
    /// </para><para>
    ///  If Amazon ML cannot accept the input source, it sets the <code>Status</code> parameter
    /// to <code>FAILED</code> and includes an error message in the <code>Message</code> attribute
    /// of the <a>GetDataSource</a> operation response. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLDataSourceFromRDS", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateDataSourceFromRDS operation against Amazon Machine Learning.", Operation = new[] {"CreateDataSourceFromRDS"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type CreateDataSourceFromRDSResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewMLDataSourceFromRDSCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The compute statistics for a <code>DataSource</code>. The statistics are generated
        /// from the observation data referenced by a <code>DataSource</code>. Amazon ML uses
        /// the statistics internally during an <code>MLModel</code> training. This parameter
        /// must be set to <code>true</code> if the <code></code>DataSource<code></code> needs
        /// to be used for <code>MLModel</code> training. </para>
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
        [Alias("RDSData_DatabaseInformation_DatabaseName")]
        public String DatabaseInformation_DatabaseName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>DataRearrangement - A JSON string that represents the splitting requirement of a <code>DataSource</code>.
        /// </para><para> Sample - <code> "{\"splitting\":{\"percentBegin\":10,\"percentEnd\":60}}"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RDSData_DataRearrangement { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A JSON string that represents the schema for an Amazon RDS <code>DataSource</code>.
        /// The <code>DataSchema</code> defines the structure of the observation data in the data
        /// file(s) referenced in the <code>DataSource</code>.</para><para>A <code>DataSchema</code> is not required if you specify a <code>DataSchemaUri</code></para><para>Define your <code>DataSchema</code> as a series of key-value pairs. <code>attributes</code>
        /// and <code>excludedVariableNames</code> have an array of key-value pairs for their
        /// value. Use the following format to define your <code>DataSchema</code>.</para><para>{ "version": "1.0",</para><para> "recordAnnotationFieldName": "F1",</para><para> "recordWeightFieldName": "F2",</para><para> "targetFieldName": "F3",</para><para> "dataFormat": "CSV",</para><para> "dataFileContainsHeader": true,</para><para> "attributes": [</para><para> { "fieldName": "F1", "fieldType": "TEXT" }, { "fieldName": "F2", "fieldType": "NUMERIC"
        /// }, { "fieldName": "F3", "fieldType": "CATEGORICAL" }, { "fieldName": "F4", "fieldType":
        /// "NUMERIC" }, { "fieldName": "F5", "fieldType": "CATEGORICAL" }, { "fieldName": "F6",
        /// "fieldType": "TEXT" }, { "fieldName": "F7", "fieldType": "WEIGHTED_INT_SEQUENCE" },
        /// { "fieldName": "F8", "fieldType": "WEIGHTED_STRING_SEQUENCE" } ],</para><para> "excludedVariableNames": [ "F6" ] } </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RDSData_DataSchema { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location of the <code>DataSchema</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RDSData_DataSchemaUri { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A user-supplied ID that uniquely identifies the <code>DataSource</code>. Typically,
        /// an Amazon Resource Number (ARN) becomes the ID for a <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSourceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A user-supplied name or description of the <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSourceName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of an RDS DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RDSData_DatabaseInformation_InstanceIdentifier")]
        public String DatabaseInformation_InstanceIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RDSData_DatabaseCredentials_Password")]
        public String DatabaseCredentials_Password { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The role (DataPipelineDefaultResourceRole) assumed by an Amazon Elastic Compute Cloud
        /// (Amazon EC2) instance to carry out the copy operation from Amazon RDS to an Amazon
        /// S3 task. For more information, see <a href="http://docs.aws.amazon.com/datapipeline/latest/DeveloperGuide/dp-iam-roles.html">Role
        /// templates</a> for data pipelines.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RDSData_ResourceRole { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The role that Amazon ML assumes on behalf of the user to create and activate a data
        /// pipeline in the user’s account and copy data (using the <code>SelectSqlQuery</code>)
        /// query from Amazon RDS to Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RoleARN { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location for staging Amazon RDS data. The data retrieved from Amazon
        /// RDS using <code>SelectSqlQuery</code> is stored in this location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RDSData_S3StagingLocation { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The security group IDs to be used to access a VPC-based RDS DB instance. Ensure that
        /// there are appropriate ingress rules set up to allow access to the RDS DB instance.
        /// This attribute is used by Data Pipeline to carry out the copy operation from Amazon
        /// RDS to an Amazon S3 task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RDSData_SecurityGroupIds")]
        public System.String[] RDSData_SecurityGroupId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The query that is used to retrieve the observation data for the <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RDSData_SelectSqlQuery { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The role (DataPipelineDefaultRole) assumed by AWS Data Pipeline service to monitor
        /// the progress of the copy task from Amazon RDS to Amazon S3. For more information,
        /// see <a href="http://docs.aws.amazon.com/datapipeline/latest/DeveloperGuide/dp-iam-roles.html">Role
        /// templates</a> for data pipelines.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RDSData_ServiceRole { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The subnet ID to be used to access a VPC-based RDS DB instance. This attribute is
        /// used by Data Pipeline to carry out the copy task from Amazon RDS to Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RDSData_SubnetId { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RDSData_DatabaseCredentials_Username")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLDataSourceFromRDS (CreateDataSourceFromRDS)"))
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
            context.RDSData_DatabaseCredentials_Password = this.DatabaseCredentials_Password;
            context.RDSData_DatabaseCredentials_Username = this.DatabaseCredentials_Username;
            context.RDSData_DatabaseInformation_DatabaseName = this.DatabaseInformation_DatabaseName;
            context.RDSData_DatabaseInformation_InstanceIdentifier = this.DatabaseInformation_InstanceIdentifier;
            context.RDSData_DataRearrangement = this.RDSData_DataRearrangement;
            context.RDSData_DataSchema = this.RDSData_DataSchema;
            context.RDSData_DataSchemaUri = this.RDSData_DataSchemaUri;
            context.RDSData_ResourceRole = this.RDSData_ResourceRole;
            context.RDSData_S3StagingLocation = this.RDSData_S3StagingLocation;
            if (this.RDSData_SecurityGroupId != null)
            {
                context.RDSData_SecurityGroupIds = new List<String>(this.RDSData_SecurityGroupId);
            }
            context.RDSData_SelectSqlQuery = this.RDSData_SelectSqlQuery;
            context.RDSData_ServiceRole = this.RDSData_ServiceRole;
            context.RDSData_SubnetId = this.RDSData_SubnetId;
            context.RoleARN = this.RoleARN;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateDataSourceFromRDSRequest();
            
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
            
             // populate RDSData
            bool requestRDSDataIsNull = true;
            request.RDSData = new RDSDataSpec();
            String requestRDSData_rDSData_DataRearrangement = null;
            if (cmdletContext.RDSData_DataRearrangement != null)
            {
                requestRDSData_rDSData_DataRearrangement = cmdletContext.RDSData_DataRearrangement;
            }
            if (requestRDSData_rDSData_DataRearrangement != null)
            {
                request.RDSData.DataRearrangement = requestRDSData_rDSData_DataRearrangement;
                requestRDSDataIsNull = false;
            }
            String requestRDSData_rDSData_DataSchema = null;
            if (cmdletContext.RDSData_DataSchema != null)
            {
                requestRDSData_rDSData_DataSchema = cmdletContext.RDSData_DataSchema;
            }
            if (requestRDSData_rDSData_DataSchema != null)
            {
                request.RDSData.DataSchema = requestRDSData_rDSData_DataSchema;
                requestRDSDataIsNull = false;
            }
            String requestRDSData_rDSData_DataSchemaUri = null;
            if (cmdletContext.RDSData_DataSchemaUri != null)
            {
                requestRDSData_rDSData_DataSchemaUri = cmdletContext.RDSData_DataSchemaUri;
            }
            if (requestRDSData_rDSData_DataSchemaUri != null)
            {
                request.RDSData.DataSchemaUri = requestRDSData_rDSData_DataSchemaUri;
                requestRDSDataIsNull = false;
            }
            String requestRDSData_rDSData_ResourceRole = null;
            if (cmdletContext.RDSData_ResourceRole != null)
            {
                requestRDSData_rDSData_ResourceRole = cmdletContext.RDSData_ResourceRole;
            }
            if (requestRDSData_rDSData_ResourceRole != null)
            {
                request.RDSData.ResourceRole = requestRDSData_rDSData_ResourceRole;
                requestRDSDataIsNull = false;
            }
            String requestRDSData_rDSData_S3StagingLocation = null;
            if (cmdletContext.RDSData_S3StagingLocation != null)
            {
                requestRDSData_rDSData_S3StagingLocation = cmdletContext.RDSData_S3StagingLocation;
            }
            if (requestRDSData_rDSData_S3StagingLocation != null)
            {
                request.RDSData.S3StagingLocation = requestRDSData_rDSData_S3StagingLocation;
                requestRDSDataIsNull = false;
            }
            List<String> requestRDSData_rDSData_SecurityGroupId = null;
            if (cmdletContext.RDSData_SecurityGroupIds != null)
            {
                requestRDSData_rDSData_SecurityGroupId = cmdletContext.RDSData_SecurityGroupIds;
            }
            if (requestRDSData_rDSData_SecurityGroupId != null)
            {
                request.RDSData.SecurityGroupIds = requestRDSData_rDSData_SecurityGroupId;
                requestRDSDataIsNull = false;
            }
            String requestRDSData_rDSData_SelectSqlQuery = null;
            if (cmdletContext.RDSData_SelectSqlQuery != null)
            {
                requestRDSData_rDSData_SelectSqlQuery = cmdletContext.RDSData_SelectSqlQuery;
            }
            if (requestRDSData_rDSData_SelectSqlQuery != null)
            {
                request.RDSData.SelectSqlQuery = requestRDSData_rDSData_SelectSqlQuery;
                requestRDSDataIsNull = false;
            }
            String requestRDSData_rDSData_ServiceRole = null;
            if (cmdletContext.RDSData_ServiceRole != null)
            {
                requestRDSData_rDSData_ServiceRole = cmdletContext.RDSData_ServiceRole;
            }
            if (requestRDSData_rDSData_ServiceRole != null)
            {
                request.RDSData.ServiceRole = requestRDSData_rDSData_ServiceRole;
                requestRDSDataIsNull = false;
            }
            String requestRDSData_rDSData_SubnetId = null;
            if (cmdletContext.RDSData_SubnetId != null)
            {
                requestRDSData_rDSData_SubnetId = cmdletContext.RDSData_SubnetId;
            }
            if (requestRDSData_rDSData_SubnetId != null)
            {
                request.RDSData.SubnetId = requestRDSData_rDSData_SubnetId;
                requestRDSDataIsNull = false;
            }
            RDSDatabaseCredentials requestRDSData_rDSData_DatabaseCredentials = null;
            
             // populate DatabaseCredentials
            bool requestRDSData_rDSData_DatabaseCredentialsIsNull = true;
            requestRDSData_rDSData_DatabaseCredentials = new RDSDatabaseCredentials();
            String requestRDSData_rDSData_DatabaseCredentials_databaseCredentials_Password = null;
            if (cmdletContext.RDSData_DatabaseCredentials_Password != null)
            {
                requestRDSData_rDSData_DatabaseCredentials_databaseCredentials_Password = cmdletContext.RDSData_DatabaseCredentials_Password;
            }
            if (requestRDSData_rDSData_DatabaseCredentials_databaseCredentials_Password != null)
            {
                requestRDSData_rDSData_DatabaseCredentials.Password = requestRDSData_rDSData_DatabaseCredentials_databaseCredentials_Password;
                requestRDSData_rDSData_DatabaseCredentialsIsNull = false;
            }
            String requestRDSData_rDSData_DatabaseCredentials_databaseCredentials_Username = null;
            if (cmdletContext.RDSData_DatabaseCredentials_Username != null)
            {
                requestRDSData_rDSData_DatabaseCredentials_databaseCredentials_Username = cmdletContext.RDSData_DatabaseCredentials_Username;
            }
            if (requestRDSData_rDSData_DatabaseCredentials_databaseCredentials_Username != null)
            {
                requestRDSData_rDSData_DatabaseCredentials.Username = requestRDSData_rDSData_DatabaseCredentials_databaseCredentials_Username;
                requestRDSData_rDSData_DatabaseCredentialsIsNull = false;
            }
             // determine if requestRDSData_rDSData_DatabaseCredentials should be set to null
            if (requestRDSData_rDSData_DatabaseCredentialsIsNull)
            {
                requestRDSData_rDSData_DatabaseCredentials = null;
            }
            if (requestRDSData_rDSData_DatabaseCredentials != null)
            {
                request.RDSData.DatabaseCredentials = requestRDSData_rDSData_DatabaseCredentials;
                requestRDSDataIsNull = false;
            }
            RDSDatabase requestRDSData_rDSData_DatabaseInformation = null;
            
             // populate DatabaseInformation
            bool requestRDSData_rDSData_DatabaseInformationIsNull = true;
            requestRDSData_rDSData_DatabaseInformation = new RDSDatabase();
            String requestRDSData_rDSData_DatabaseInformation_databaseInformation_DatabaseName = null;
            if (cmdletContext.RDSData_DatabaseInformation_DatabaseName != null)
            {
                requestRDSData_rDSData_DatabaseInformation_databaseInformation_DatabaseName = cmdletContext.RDSData_DatabaseInformation_DatabaseName;
            }
            if (requestRDSData_rDSData_DatabaseInformation_databaseInformation_DatabaseName != null)
            {
                requestRDSData_rDSData_DatabaseInformation.DatabaseName = requestRDSData_rDSData_DatabaseInformation_databaseInformation_DatabaseName;
                requestRDSData_rDSData_DatabaseInformationIsNull = false;
            }
            String requestRDSData_rDSData_DatabaseInformation_databaseInformation_InstanceIdentifier = null;
            if (cmdletContext.RDSData_DatabaseInformation_InstanceIdentifier != null)
            {
                requestRDSData_rDSData_DatabaseInformation_databaseInformation_InstanceIdentifier = cmdletContext.RDSData_DatabaseInformation_InstanceIdentifier;
            }
            if (requestRDSData_rDSData_DatabaseInformation_databaseInformation_InstanceIdentifier != null)
            {
                requestRDSData_rDSData_DatabaseInformation.InstanceIdentifier = requestRDSData_rDSData_DatabaseInformation_databaseInformation_InstanceIdentifier;
                requestRDSData_rDSData_DatabaseInformationIsNull = false;
            }
             // determine if requestRDSData_rDSData_DatabaseInformation should be set to null
            if (requestRDSData_rDSData_DatabaseInformationIsNull)
            {
                requestRDSData_rDSData_DatabaseInformation = null;
            }
            if (requestRDSData_rDSData_DatabaseInformation != null)
            {
                request.RDSData.DatabaseInformation = requestRDSData_rDSData_DatabaseInformation;
                requestRDSDataIsNull = false;
            }
             // determine if request.RDSData should be set to null
            if (requestRDSDataIsNull)
            {
                request.RDSData = null;
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
                var response = client.CreateDataSourceFromRDS(request);
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
            public String RDSData_DatabaseCredentials_Password { get; set; }
            public String RDSData_DatabaseCredentials_Username { get; set; }
            public String RDSData_DatabaseInformation_DatabaseName { get; set; }
            public String RDSData_DatabaseInformation_InstanceIdentifier { get; set; }
            public String RDSData_DataRearrangement { get; set; }
            public String RDSData_DataSchema { get; set; }
            public String RDSData_DataSchemaUri { get; set; }
            public String RDSData_ResourceRole { get; set; }
            public String RDSData_S3StagingLocation { get; set; }
            public List<String> RDSData_SecurityGroupIds { get; set; }
            public String RDSData_SelectSqlQuery { get; set; }
            public String RDSData_ServiceRole { get; set; }
            public String RDSData_SubnetId { get; set; }
            public String RoleARN { get; set; }
        }
        
    }
}
