/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Start importing bulk FHIR data into an ACTIVE data store. The import job imports FHIR
    /// data found in the <c>InputDataConfig</c> object and stores processing results in the
    /// <c>JobOutputDataConfig</c> object.
    /// </summary>
    [Cmdlet("Start", "AHLFHIRImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.HealthLake.Model.StartFHIRImportJobResponse")]
    [AWSCmdlet("Calls the Amazon HealthLake StartFHIRImportJob API operation.", Operation = new[] {"StartFHIRImportJob"}, SelectReturnType = typeof(Amazon.HealthLake.Model.StartFHIRImportJobResponse))]
    [AWSCmdletOutput("Amazon.HealthLake.Model.StartFHIRImportJobResponse",
        "This cmdlet returns an Amazon.HealthLake.Model.StartFHIRImportJobResponse object containing multiple properties."
    )]
    public partial class StartAHLFHIRImportJobCmdlet : AmazonHealthLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that grants access permission to AWS HealthLake.</para>
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
        /// <para>The data store identifier.</para>
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
        public System.String DatastoreId { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The import job name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter S3Configuration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service (KMS) key ID used to access the S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobOutputDataConfig_S3Configuration_KmsKeyId")]
        public System.String S3Configuration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The <c>S3Uri</c> is the user-specified S3 location of the FHIR data to be imported
        /// into AWS HealthLake.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter S3Configuration_S3Uri
        /// <summary>
        /// <para>
        /// <para>The <c>S3Uri</c> is the user-specified S3 location of the FHIR data to be imported
        /// into AWS HealthLake.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobOutputDataConfig_S3Configuration_S3Uri")]
        public System.String S3Configuration_S3Uri { get; set; }
        #endregion
        
        #region Parameter ValidationLevel
        /// <summary>
        /// <para>
        /// <para>The validation level of the import job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.HealthLake.ValidationLevel")]
        public Amazon.HealthLake.ValidationLevel ValidationLevel { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The optional user-provided token used for ensuring API idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.HealthLake.Model.StartFHIRImportJobResponse).
        /// Specifying the name of a property of type Amazon.HealthLake.Model.StartFHIRImportJobResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-AHLFHIRImportJob (StartFHIRImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.HealthLake.Model.StartFHIRImportJobResponse, StartAHLFHIRImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.InputDataConfig_S3Uri = this.InputDataConfig_S3Uri;
            context.JobName = this.JobName;
            context.S3Configuration_KmsKeyId = this.S3Configuration_KmsKeyId;
            context.S3Configuration_S3Uri = this.S3Configuration_S3Uri;
            context.ValidationLevel = this.ValidationLevel;
            
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
            var request = new Amazon.HealthLake.Model.StartFHIRImportJobRequest();
            
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
            
             // populate InputDataConfig
            request.InputDataConfig = new Amazon.HealthLake.Model.InputDataConfig();
            System.String requestInputDataConfig_inputDataConfig_S3Uri = null;
            if (cmdletContext.InputDataConfig_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_S3Uri = cmdletContext.InputDataConfig_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_S3Uri != null)
            {
                request.InputDataConfig.S3Uri = requestInputDataConfig_inputDataConfig_S3Uri;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            
             // populate JobOutputDataConfig
            request.JobOutputDataConfig = new Amazon.HealthLake.Model.OutputDataConfig();
            Amazon.HealthLake.Model.S3Configuration requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration = null;
            
             // populate S3Configuration
            var requestJobOutputDataConfig_jobOutputDataConfig_S3ConfigurationIsNull = true;
            requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration = new Amazon.HealthLake.Model.S3Configuration();
            System.String requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration_s3Configuration_KmsKeyId = null;
            if (cmdletContext.S3Configuration_KmsKeyId != null)
            {
                requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration_s3Configuration_KmsKeyId = cmdletContext.S3Configuration_KmsKeyId;
            }
            if (requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration_s3Configuration_KmsKeyId != null)
            {
                requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration.KmsKeyId = requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration_s3Configuration_KmsKeyId;
                requestJobOutputDataConfig_jobOutputDataConfig_S3ConfigurationIsNull = false;
            }
            System.String requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration_s3Configuration_S3Uri = null;
            if (cmdletContext.S3Configuration_S3Uri != null)
            {
                requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration_s3Configuration_S3Uri = cmdletContext.S3Configuration_S3Uri;
            }
            if (requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration_s3Configuration_S3Uri != null)
            {
                requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration.S3Uri = requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration_s3Configuration_S3Uri;
                requestJobOutputDataConfig_jobOutputDataConfig_S3ConfigurationIsNull = false;
            }
             // determine if requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration should be set to null
            if (requestJobOutputDataConfig_jobOutputDataConfig_S3ConfigurationIsNull)
            {
                requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration = null;
            }
            if (requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration != null)
            {
                request.JobOutputDataConfig.S3Configuration = requestJobOutputDataConfig_jobOutputDataConfig_S3Configuration;
            }
            if (cmdletContext.ValidationLevel != null)
            {
                request.ValidationLevel = cmdletContext.ValidationLevel;
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
        
        private Amazon.HealthLake.Model.StartFHIRImportJobResponse CallAWSServiceOperation(IAmazonHealthLake client, Amazon.HealthLake.Model.StartFHIRImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon HealthLake", "StartFHIRImportJob");
            try
            {
                #if DESKTOP
                return client.StartFHIRImportJob(request);
                #elif CORECLR
                return client.StartFHIRImportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String InputDataConfig_S3Uri { get; set; }
            public System.String JobName { get; set; }
            public System.String S3Configuration_KmsKeyId { get; set; }
            public System.String S3Configuration_S3Uri { get; set; }
            public Amazon.HealthLake.ValidationLevel ValidationLevel { get; set; }
            public System.Func<Amazon.HealthLake.Model.StartFHIRImportJobResponse, StartAHLFHIRImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
