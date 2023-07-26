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
using Amazon.HealthLake;
using Amazon.HealthLake.Model;

namespace Amazon.PowerShell.Cmdlets.AHL
{
    /// <summary>
    /// Begins a FHIR export job.
    /// </summary>
    [Cmdlet("Start", "AHLFHIRExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.HealthLake.Model.StartFHIRExportJobResponse")]
    [AWSCmdlet("Calls the Amazon HealthLake StartFHIRExportJob API operation.", Operation = new[] {"StartFHIRExportJob"}, SelectReturnType = typeof(Amazon.HealthLake.Model.StartFHIRExportJobResponse))]
    [AWSCmdletOutput("Amazon.HealthLake.Model.StartFHIRExportJobResponse",
        "This cmdlet returns an Amazon.HealthLake.Model.StartFHIRExportJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartAHLFHIRExportJobCmdlet : AmazonHealthLakeClientCmdlet, IExecutor
    {
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name used during the initiation of the job.</para>
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
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter DatastoreId
        /// <summary>
        /// <para>
        /// <para>The AWS generated ID for the data store from which files are being exported for an
        /// export job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DatastoreId { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The user generated name for an export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter S3Configuration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para> The KMS key ID used to access the S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputDataConfig_S3Configuration_KmsKeyId")]
        public System.String S3Configuration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter S3Configuration_S3Uri
        /// <summary>
        /// <para>
        /// <para> The S3Uri is the user specified S3 location of the FHIR data to be imported into
        /// AWS HealthLake. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputDataConfig_S3Configuration_S3Uri")]
        public System.String S3Configuration_S3Uri { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An optional user provided token used for ensuring idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.HealthLake.Model.StartFHIRExportJobResponse).
        /// Specifying the name of a property of type Amazon.HealthLake.Model.StartFHIRExportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatastoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatastoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatastoreId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatastoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-AHLFHIRExportJob (StartFHIRExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.HealthLake.Model.StartFHIRExportJobResponse, StartAHLFHIRExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatastoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatastoreId = this.DatastoreId;
            #if MODULAR
            if (this.DatastoreId == null && ParameterWasBound(nameof(this.DatastoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatastoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobName = this.JobName;
            context.S3Configuration_KmsKeyId = this.S3Configuration_KmsKeyId;
            context.S3Configuration_S3Uri = this.S3Configuration_S3Uri;
            
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
            var request = new Amazon.HealthLake.Model.StartFHIRExportJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            if (cmdletContext.DatastoreId != null)
            {
                request.DatastoreId = cmdletContext.DatastoreId;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.HealthLake.Model.OutputDataConfig();
            Amazon.HealthLake.Model.S3Configuration requestOutputDataConfig_outputDataConfig_S3Configuration = null;
            
             // populate S3Configuration
            var requestOutputDataConfig_outputDataConfig_S3ConfigurationIsNull = true;
            requestOutputDataConfig_outputDataConfig_S3Configuration = new Amazon.HealthLake.Model.S3Configuration();
            System.String requestOutputDataConfig_outputDataConfig_S3Configuration_s3Configuration_KmsKeyId = null;
            if (cmdletContext.S3Configuration_KmsKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Configuration_s3Configuration_KmsKeyId = cmdletContext.S3Configuration_KmsKeyId;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Configuration_s3Configuration_KmsKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Configuration.KmsKeyId = requestOutputDataConfig_outputDataConfig_S3Configuration_s3Configuration_KmsKeyId;
                requestOutputDataConfig_outputDataConfig_S3ConfigurationIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3Configuration_s3Configuration_S3Uri = null;
            if (cmdletContext.S3Configuration_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Configuration_s3Configuration_S3Uri = cmdletContext.S3Configuration_S3Uri;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Configuration_s3Configuration_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Configuration.S3Uri = requestOutputDataConfig_outputDataConfig_S3Configuration_s3Configuration_S3Uri;
                requestOutputDataConfig_outputDataConfig_S3ConfigurationIsNull = false;
            }
             // determine if requestOutputDataConfig_outputDataConfig_S3Configuration should be set to null
            if (requestOutputDataConfig_outputDataConfig_S3ConfigurationIsNull)
            {
                requestOutputDataConfig_outputDataConfig_S3Configuration = null;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Configuration != null)
            {
                request.OutputDataConfig.S3Configuration = requestOutputDataConfig_outputDataConfig_S3Configuration;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
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
        
        private Amazon.HealthLake.Model.StartFHIRExportJobResponse CallAWSServiceOperation(IAmazonHealthLake client, Amazon.HealthLake.Model.StartFHIRExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon HealthLake", "StartFHIRExportJob");
            try
            {
                #if DESKTOP
                return client.StartFHIRExportJob(request);
                #elif CORECLR
                return client.StartFHIRExportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String DataAccessRoleArn { get; set; }
            public System.String DatastoreId { get; set; }
            public System.String JobName { get; set; }
            public System.String S3Configuration_KmsKeyId { get; set; }
            public System.String S3Configuration_S3Uri { get; set; }
            public System.Func<Amazon.HealthLake.Model.StartFHIRExportJobResponse, StartAHLFHIRExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
