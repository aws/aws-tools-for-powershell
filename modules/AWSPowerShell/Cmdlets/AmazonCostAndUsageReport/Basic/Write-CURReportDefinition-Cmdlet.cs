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
using Amazon.CostAndUsageReport;
using Amazon.CostAndUsageReport.Model;

namespace Amazon.PowerShell.Cmdlets.CUR
{
    /// <summary>
    /// Create a new report definition
    /// </summary>
    [Cmdlet("Write", "CURReportDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the PutReportDefinition operation against AWS Cost and Usage Report.", Operation = new[] {"PutReportDefinition"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.CostAndUsageReport.Model.PutReportDefinitionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCURReportDefinitionCmdlet : AmazonCostAndUsageReportClientCmdlet, IExecutor
    {
        
        #region Parameter ReportDefinition_AdditionalArtifact
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReportDefinition_AdditionalArtifacts")]
        public System.String[] ReportDefinition_AdditionalArtifact { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_AdditionalSchemaElement
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReportDefinition_AdditionalSchemaElements")]
        public System.String[] ReportDefinition_AdditionalSchemaElement { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_Compression
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CostAndUsageReport.CompressionFormat")]
        public Amazon.CostAndUsageReport.CompressionFormat ReportDefinition_Compression { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_Format
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CostAndUsageReport.ReportFormat")]
        public Amazon.CostAndUsageReport.ReportFormat ReportDefinition_Format { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_ReportName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReportDefinition_ReportName { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_S3Bucket
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReportDefinition_S3Bucket { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_S3Prefix
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReportDefinition_S3Prefix { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_S3Region
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CostAndUsageReport.AWSRegion")]
        public Amazon.CostAndUsageReport.AWSRegion ReportDefinition_S3Region { get; set; }
        #endregion
        
        #region Parameter ReportDefinition_TimeUnit
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CostAndUsageReport.TimeUnit")]
        public Amazon.CostAndUsageReport.TimeUnit ReportDefinition_TimeUnit { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReportDefinition_ReportName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CURReportDefinition (PutReportDefinition)"))
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
            
            if (this.ReportDefinition_AdditionalArtifact != null)
            {
                context.ReportDefinition_AdditionalArtifacts = new List<System.String>(this.ReportDefinition_AdditionalArtifact);
            }
            if (this.ReportDefinition_AdditionalSchemaElement != null)
            {
                context.ReportDefinition_AdditionalSchemaElements = new List<System.String>(this.ReportDefinition_AdditionalSchemaElement);
            }
            context.ReportDefinition_Compression = this.ReportDefinition_Compression;
            context.ReportDefinition_Format = this.ReportDefinition_Format;
            context.ReportDefinition_ReportName = this.ReportDefinition_ReportName;
            context.ReportDefinition_S3Bucket = this.ReportDefinition_S3Bucket;
            context.ReportDefinition_S3Prefix = this.ReportDefinition_S3Prefix;
            context.ReportDefinition_S3Region = this.ReportDefinition_S3Region;
            context.ReportDefinition_TimeUnit = this.ReportDefinition_TimeUnit;
            
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
            var request = new Amazon.CostAndUsageReport.Model.PutReportDefinitionRequest();
            
            
             // populate ReportDefinition
            bool requestReportDefinitionIsNull = true;
            request.ReportDefinition = new Amazon.CostAndUsageReport.Model.ReportDefinition();
            List<System.String> requestReportDefinition_reportDefinition_AdditionalArtifact = null;
            if (cmdletContext.ReportDefinition_AdditionalArtifacts != null)
            {
                requestReportDefinition_reportDefinition_AdditionalArtifact = cmdletContext.ReportDefinition_AdditionalArtifacts;
            }
            if (requestReportDefinition_reportDefinition_AdditionalArtifact != null)
            {
                request.ReportDefinition.AdditionalArtifacts = requestReportDefinition_reportDefinition_AdditionalArtifact;
                requestReportDefinitionIsNull = false;
            }
            List<System.String> requestReportDefinition_reportDefinition_AdditionalSchemaElement = null;
            if (cmdletContext.ReportDefinition_AdditionalSchemaElements != null)
            {
                requestReportDefinition_reportDefinition_AdditionalSchemaElement = cmdletContext.ReportDefinition_AdditionalSchemaElements;
            }
            if (requestReportDefinition_reportDefinition_AdditionalSchemaElement != null)
            {
                request.ReportDefinition.AdditionalSchemaElements = requestReportDefinition_reportDefinition_AdditionalSchemaElement;
                requestReportDefinitionIsNull = false;
            }
            Amazon.CostAndUsageReport.CompressionFormat requestReportDefinition_reportDefinition_Compression = null;
            if (cmdletContext.ReportDefinition_Compression != null)
            {
                requestReportDefinition_reportDefinition_Compression = cmdletContext.ReportDefinition_Compression;
            }
            if (requestReportDefinition_reportDefinition_Compression != null)
            {
                request.ReportDefinition.Compression = requestReportDefinition_reportDefinition_Compression;
                requestReportDefinitionIsNull = false;
            }
            Amazon.CostAndUsageReport.ReportFormat requestReportDefinition_reportDefinition_Format = null;
            if (cmdletContext.ReportDefinition_Format != null)
            {
                requestReportDefinition_reportDefinition_Format = cmdletContext.ReportDefinition_Format;
            }
            if (requestReportDefinition_reportDefinition_Format != null)
            {
                request.ReportDefinition.Format = requestReportDefinition_reportDefinition_Format;
                requestReportDefinitionIsNull = false;
            }
            System.String requestReportDefinition_reportDefinition_ReportName = null;
            if (cmdletContext.ReportDefinition_ReportName != null)
            {
                requestReportDefinition_reportDefinition_ReportName = cmdletContext.ReportDefinition_ReportName;
            }
            if (requestReportDefinition_reportDefinition_ReportName != null)
            {
                request.ReportDefinition.ReportName = requestReportDefinition_reportDefinition_ReportName;
                requestReportDefinitionIsNull = false;
            }
            System.String requestReportDefinition_reportDefinition_S3Bucket = null;
            if (cmdletContext.ReportDefinition_S3Bucket != null)
            {
                requestReportDefinition_reportDefinition_S3Bucket = cmdletContext.ReportDefinition_S3Bucket;
            }
            if (requestReportDefinition_reportDefinition_S3Bucket != null)
            {
                request.ReportDefinition.S3Bucket = requestReportDefinition_reportDefinition_S3Bucket;
                requestReportDefinitionIsNull = false;
            }
            System.String requestReportDefinition_reportDefinition_S3Prefix = null;
            if (cmdletContext.ReportDefinition_S3Prefix != null)
            {
                requestReportDefinition_reportDefinition_S3Prefix = cmdletContext.ReportDefinition_S3Prefix;
            }
            if (requestReportDefinition_reportDefinition_S3Prefix != null)
            {
                request.ReportDefinition.S3Prefix = requestReportDefinition_reportDefinition_S3Prefix;
                requestReportDefinitionIsNull = false;
            }
            Amazon.CostAndUsageReport.AWSRegion requestReportDefinition_reportDefinition_S3Region = null;
            if (cmdletContext.ReportDefinition_S3Region != null)
            {
                requestReportDefinition_reportDefinition_S3Region = cmdletContext.ReportDefinition_S3Region;
            }
            if (requestReportDefinition_reportDefinition_S3Region != null)
            {
                request.ReportDefinition.S3Region = requestReportDefinition_reportDefinition_S3Region;
                requestReportDefinitionIsNull = false;
            }
            Amazon.CostAndUsageReport.TimeUnit requestReportDefinition_reportDefinition_TimeUnit = null;
            if (cmdletContext.ReportDefinition_TimeUnit != null)
            {
                requestReportDefinition_reportDefinition_TimeUnit = cmdletContext.ReportDefinition_TimeUnit;
            }
            if (requestReportDefinition_reportDefinition_TimeUnit != null)
            {
                request.ReportDefinition.TimeUnit = requestReportDefinition_reportDefinition_TimeUnit;
                requestReportDefinitionIsNull = false;
            }
             // determine if request.ReportDefinition should be set to null
            if (requestReportDefinitionIsNull)
            {
                request.ReportDefinition = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.CostAndUsageReport.Model.PutReportDefinitionResponse CallAWSServiceOperation(IAmazonCostAndUsageReport client, Amazon.CostAndUsageReport.Model.PutReportDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost and Usage Report", "PutReportDefinition");
            try
            {
                #if DESKTOP
                return client.PutReportDefinition(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutReportDefinitionAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<System.String> ReportDefinition_AdditionalArtifacts { get; set; }
            public List<System.String> ReportDefinition_AdditionalSchemaElements { get; set; }
            public Amazon.CostAndUsageReport.CompressionFormat ReportDefinition_Compression { get; set; }
            public Amazon.CostAndUsageReport.ReportFormat ReportDefinition_Format { get; set; }
            public System.String ReportDefinition_ReportName { get; set; }
            public System.String ReportDefinition_S3Bucket { get; set; }
            public System.String ReportDefinition_S3Prefix { get; set; }
            public Amazon.CostAndUsageReport.AWSRegion ReportDefinition_S3Region { get; set; }
            public Amazon.CostAndUsageReport.TimeUnit ReportDefinition_TimeUnit { get; set; }
        }
        
    }
}
