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
    /// Creates a <code>DataSource</code> object. A <code>DataSource</code> references data
    /// that can be used to perform <a>CreateMLModel</a>, <a>CreateEvaluation</a>, or <a>CreateBatchPrediction</a>
    /// operations.
    /// 
    ///  
    /// <para><code>CreateDataSourceFromS3</code> is an asynchronous operation. In response to <code>CreateDataSourceFromS3</code>,
    /// Amazon Machine Learning (Amazon ML) immediately returns and sets the <code>DataSource</code>
    /// status to <code>PENDING</code>. After the <code>DataSource</code> is created and ready
    /// for use, Amazon ML sets the <code>Status</code> parameter to <code>COMPLETED</code>.
    /// <code>DataSource</code> in <code>COMPLETED</code> or <code>PENDING</code> status can
    /// only be used to perform <a>CreateMLModel</a>, <a>CreateEvaluation</a> or <a>CreateBatchPrediction</a>
    /// operations. 
    /// </para><para>
    ///  If Amazon ML cannot accept the input source, it sets the <code>Status</code> parameter
    /// to <code>FAILED</code> and includes an error message in the <code>Message</code> attribute
    /// of the <a>GetDataSource</a> operation response. 
    /// </para><para>
    /// The observation data used in a <code>DataSource</code> should be ready to use; that
    /// is, it should have a consistent structure, and missing data values should be kept
    /// to a minimum. The observation data must reside in one or more CSV files in an Amazon
    /// Simple Storage Service (Amazon S3) bucket, along with a schema that describes the
    /// data items by name and type. The same schema must be used for all of the data files
    /// referenced by the <code>DataSource</code>. 
    /// </para><para>
    /// After the <code>DataSource</code> has been created, it's ready to use in evaluations
    /// and batch predictions. If you plan to use the <code>DataSource</code> to train an
    /// <code>MLModel</code>, the <code>DataSource</code> requires another item: a recipe.
    /// A recipe describes the observation variables that participate in training an <code>MLModel</code>.
    /// A recipe describes how each input variable will be used in training. Will the variable
    /// be included or excluded from training? Will the variable be manipulated, for example,
    /// combined with another variable, or split apart into word combinations? The recipe
    /// provides answers to these questions. For more information, see the <a href="http://docs.aws.amazon.com/machine-learning/latest/dg">Amazon
    /// Machine Learning Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MLDataSourceFromS3", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateDataSourceFromS3 operation against Amazon Machine Learning.", Operation = new[] {"CreateDataSourceFromS3"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type CreateDataSourceFromS3Response) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewMLDataSourceFromS3Cmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The compute statistics for a <code>DataSource</code>. The statistics are generated
        /// from the observation data referenced by a <code>DataSource</code>. Amazon ML uses
        /// the statistics internally during an <code>MLModel</code> training. This parameter
        /// must be set to <code>true</code> if the <code></code>DataSource<code></code> needs
        /// to be used for <code>MLModel</code> training</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ComputeStatistics { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The location of the data file(s) used by a <code>DataSource</code>. The URI specifies
        /// a data file or an Amazon Simple Storage Service (Amazon S3) directory or bucket containing
        /// data files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSpec_DataLocationS3 { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Describes the splitting requirement of a <code>Datasource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSpec_DataRearrangement { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A JSON string that represents the schema for an Amazon S3 <code>DataSource</code>.
        /// The <code>DataSchema</code> defines the structure of the observation data in the data
        /// file(s) referenced in the <code>DataSource</code>.</para><para>Define your <code>DataSchema</code> as a series of key-value pairs. <code>attributes</code>
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
        /// <para>Describes the schema Location in Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DataSpec_DataSchemaLocationS3 { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A user-supplied identifier that uniquely identifies the <code>DataSource</code>. </para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MLDataSourceFromS3 (CreateDataSourceFromS3)"))
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
            context.DataSpec_DataLocationS3 = this.DataSpec_DataLocationS3;
            context.DataSpec_DataRearrangement = this.DataSpec_DataRearrangement;
            context.DataSpec_DataSchema = this.DataSpec_DataSchema;
            context.DataSpec_DataSchemaLocationS3 = this.DataSpec_DataSchemaLocationS3;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateDataSourceFromS3Request();
            
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
            request.DataSpec = new S3DataSpec();
            String requestDataSpec_dataSpec_DataLocationS3 = null;
            if (cmdletContext.DataSpec_DataLocationS3 != null)
            {
                requestDataSpec_dataSpec_DataLocationS3 = cmdletContext.DataSpec_DataLocationS3;
            }
            if (requestDataSpec_dataSpec_DataLocationS3 != null)
            {
                request.DataSpec.DataLocationS3 = requestDataSpec_dataSpec_DataLocationS3;
                requestDataSpecIsNull = false;
            }
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
            String requestDataSpec_dataSpec_DataSchemaLocationS3 = null;
            if (cmdletContext.DataSpec_DataSchemaLocationS3 != null)
            {
                requestDataSpec_dataSpec_DataSchemaLocationS3 = cmdletContext.DataSpec_DataSchemaLocationS3;
            }
            if (requestDataSpec_dataSpec_DataSchemaLocationS3 != null)
            {
                request.DataSpec.DataSchemaLocationS3 = requestDataSpec_dataSpec_DataSchemaLocationS3;
                requestDataSpecIsNull = false;
            }
             // determine if request.DataSpec should be set to null
            if (requestDataSpecIsNull)
            {
                request.DataSpec = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateDataSourceFromS3(request);
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
            public String DataSpec_DataLocationS3 { get; set; }
            public String DataSpec_DataRearrangement { get; set; }
            public String DataSpec_DataSchema { get; set; }
            public String DataSpec_DataSchemaLocationS3 { get; set; }
        }
        
    }
}
