/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.LookoutEquipment;
using Amazon.LookoutEquipment.Model;

namespace Amazon.PowerShell.Cmdlets.L4E
{
    /// <summary>
    /// Starts a data ingestion job. Amazon Lookout for Equipment returns the job status.
    /// </summary>
    [Cmdlet("Start", "L4EDataIngestionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutEquipment.Model.StartDataIngestionJobResponse")]
    [AWSCmdlet("Calls the Amazon Lookout for Equipment StartDataIngestionJob API operation.", Operation = new[] {"StartDataIngestionJob"}, SelectReturnType = typeof(Amazon.LookoutEquipment.Model.StartDataIngestionJobResponse))]
    [AWSCmdletOutput("Amazon.LookoutEquipment.Model.StartDataIngestionJobResponse",
        "This cmdlet returns an Amazon.LookoutEquipment.Model.StartDataIngestionJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartL4EDataIngestionJobCmdlet : AmazonLookoutEquipmentClientCmdlet, IExecutor
    {
        
        #region Parameter S3InputConfiguration_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket used for the input data for the data ingestion. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("IngestionInputConfiguration_S3InputConfiguration_Bucket")]
        public System.String S3InputConfiguration_Bucket { get; set; }
        #endregion
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// <para>The name of the dataset being used by the data ingestion job. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DatasetName { get; set; }
        #endregion
        
        #region Parameter S3InputConfiguration_Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix for the S3 location being used for the input data for the data ingestion.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IngestionInputConfiguration_S3InputConfiguration_Prefix")]
        public System.String S3InputConfiguration_Prefix { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of a role with permission to access the data source
        /// for the data ingestion job. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier for the request. If you do not set the client request token,
        /// Amazon Lookout for Equipment generates one. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutEquipment.Model.StartDataIngestionJobResponse).
        /// Specifying the name of a property of type Amazon.LookoutEquipment.Model.StartDataIngestionJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-L4EDataIngestionJob (StartDataIngestionJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutEquipment.Model.StartDataIngestionJobResponse, StartL4EDataIngestionJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DatasetName = this.DatasetName;
            #if MODULAR
            if (this.DatasetName == null && ParameterWasBound(nameof(this.DatasetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3InputConfiguration_Bucket = this.S3InputConfiguration_Bucket;
            #if MODULAR
            if (this.S3InputConfiguration_Bucket == null && ParameterWasBound(nameof(this.S3InputConfiguration_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3InputConfiguration_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3InputConfiguration_Prefix = this.S3InputConfiguration_Prefix;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.LookoutEquipment.Model.StartDataIngestionJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            
             // populate IngestionInputConfiguration
            var requestIngestionInputConfigurationIsNull = true;
            request.IngestionInputConfiguration = new Amazon.LookoutEquipment.Model.IngestionInputConfiguration();
            Amazon.LookoutEquipment.Model.IngestionS3InputConfiguration requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration = null;
            
             // populate S3InputConfiguration
            var requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfigurationIsNull = true;
            requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration = new Amazon.LookoutEquipment.Model.IngestionS3InputConfiguration();
            System.String requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket = null;
            if (cmdletContext.S3InputConfiguration_Bucket != null)
            {
                requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket = cmdletContext.S3InputConfiguration_Bucket;
            }
            if (requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket != null)
            {
                requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration.Bucket = requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket;
                requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfigurationIsNull = false;
            }
            System.String requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix = null;
            if (cmdletContext.S3InputConfiguration_Prefix != null)
            {
                requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix = cmdletContext.S3InputConfiguration_Prefix;
            }
            if (requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix != null)
            {
                requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration.Prefix = requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix;
                requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfigurationIsNull = false;
            }
             // determine if requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration should be set to null
            if (requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfigurationIsNull)
            {
                requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration = null;
            }
            if (requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration != null)
            {
                request.IngestionInputConfiguration.S3InputConfiguration = requestIngestionInputConfiguration_ingestionInputConfiguration_S3InputConfiguration;
                requestIngestionInputConfigurationIsNull = false;
            }
             // determine if request.IngestionInputConfiguration should be set to null
            if (requestIngestionInputConfigurationIsNull)
            {
                request.IngestionInputConfiguration = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.LookoutEquipment.Model.StartDataIngestionJobResponse CallAWSServiceOperation(IAmazonLookoutEquipment client, Amazon.LookoutEquipment.Model.StartDataIngestionJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Equipment", "StartDataIngestionJob");
            try
            {
                #if DESKTOP
                return client.StartDataIngestionJob(request);
                #elif CORECLR
                return client.StartDataIngestionJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DatasetName { get; set; }
            public System.String S3InputConfiguration_Bucket { get; set; }
            public System.String S3InputConfiguration_Prefix { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.LookoutEquipment.Model.StartDataIngestionJobResponse, StartL4EDataIngestionJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
