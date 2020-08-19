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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Starts an asynchronous PII entity detection job for a collection of documents.
    /// </summary>
    [Cmdlet("Start", "COMPPiiEntitiesDetectionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobResponse")]
    [AWSCmdlet("Calls the Amazon Comprehend StartPiiEntitiesDetectionJob API operation.", Operation = new[] {"StartPiiEntitiesDetectionJob"}, SelectReturnType = typeof(Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobResponse",
        "This cmdlet returns an Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCOMPPiiEntitiesDetectionJobCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the request. If you don't set the client request token, Amazon
        /// Comprehend generates one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Access Management (IAM) role
        /// that grants Amazon Comprehend read access to your input data.</para>
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
        
        #region Parameter InputDataConfig
        /// <summary>
        /// <para>
        /// <para>The input properties for a PII entities detection job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Comprehend.Model.InputDataConfig InputDataConfig { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The identifier of the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language of the input documents.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Comprehend.LanguageCode")]
        public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter RedactionConfig_MaskCharacter
        /// <summary>
        /// <para>
        /// <para>A character that replaces each character in the redacted PII entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedactionConfig_MaskCharacter { get; set; }
        #endregion
        
        #region Parameter RedactionConfig_MaskMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the PII entity is redacted with the mask character or the entity
        /// type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.PiiEntitiesDetectionMaskMode")]
        public Amazon.Comprehend.PiiEntitiesDetectionMaskMode RedactionConfig_MaskMode { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the output provides the locations (offsets) of PII entities or a
        /// file in which PII entities are redacted.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Comprehend.PiiEntitiesDetectionMode")]
        public Amazon.Comprehend.PiiEntitiesDetectionMode Mode { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig
        /// <summary>
        /// <para>
        /// <para>Provides conﬁguration parameters for the output of PII entity detection jobs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Comprehend.Model.OutputDataConfig OutputDataConfig { get; set; }
        #endregion
        
        #region Parameter RedactionConfig_PiiEntityType
        /// <summary>
        /// <para>
        /// <para>An array of the types of PII entities that Amazon Comprehend detects in the input
        /// text for your request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RedactionConfig_PiiEntityTypes")]
        public System.String[] RedactionConfig_PiiEntityType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InputDataConfig parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InputDataConfig' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InputDataConfig' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-COMPPiiEntitiesDetectionJob (StartPiiEntitiesDetectionJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobResponse, StartCOMPPiiEntitiesDetectionJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InputDataConfig;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDataConfig = this.InputDataConfig;
            #if MODULAR
            if (this.InputDataConfig == null && ParameterWasBound(nameof(this.InputDataConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobName = this.JobName;
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Mode = this.Mode;
            #if MODULAR
            if (this.Mode == null && ParameterWasBound(nameof(this.Mode)))
            {
                WriteWarning("You are passing $null as a value for parameter Mode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputDataConfig = this.OutputDataConfig;
            #if MODULAR
            if (this.OutputDataConfig == null && ParameterWasBound(nameof(this.OutputDataConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RedactionConfig_MaskCharacter = this.RedactionConfig_MaskCharacter;
            context.RedactionConfig_MaskMode = this.RedactionConfig_MaskMode;
            if (this.RedactionConfig_PiiEntityType != null)
            {
                context.RedactionConfig_PiiEntityType = new List<System.String>(this.RedactionConfig_PiiEntityType);
            }
            
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
            var request = new Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            if (cmdletContext.InputDataConfig != null)
            {
                request.InputDataConfig = cmdletContext.InputDataConfig;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.OutputDataConfig != null)
            {
                request.OutputDataConfig = cmdletContext.OutputDataConfig;
            }
            
             // populate RedactionConfig
            var requestRedactionConfigIsNull = true;
            request.RedactionConfig = new Amazon.Comprehend.Model.RedactionConfig();
            System.String requestRedactionConfig_redactionConfig_MaskCharacter = null;
            if (cmdletContext.RedactionConfig_MaskCharacter != null)
            {
                requestRedactionConfig_redactionConfig_MaskCharacter = cmdletContext.RedactionConfig_MaskCharacter;
            }
            if (requestRedactionConfig_redactionConfig_MaskCharacter != null)
            {
                request.RedactionConfig.MaskCharacter = requestRedactionConfig_redactionConfig_MaskCharacter;
                requestRedactionConfigIsNull = false;
            }
            Amazon.Comprehend.PiiEntitiesDetectionMaskMode requestRedactionConfig_redactionConfig_MaskMode = null;
            if (cmdletContext.RedactionConfig_MaskMode != null)
            {
                requestRedactionConfig_redactionConfig_MaskMode = cmdletContext.RedactionConfig_MaskMode;
            }
            if (requestRedactionConfig_redactionConfig_MaskMode != null)
            {
                request.RedactionConfig.MaskMode = requestRedactionConfig_redactionConfig_MaskMode;
                requestRedactionConfigIsNull = false;
            }
            List<System.String> requestRedactionConfig_redactionConfig_PiiEntityType = null;
            if (cmdletContext.RedactionConfig_PiiEntityType != null)
            {
                requestRedactionConfig_redactionConfig_PiiEntityType = cmdletContext.RedactionConfig_PiiEntityType;
            }
            if (requestRedactionConfig_redactionConfig_PiiEntityType != null)
            {
                request.RedactionConfig.PiiEntityTypes = requestRedactionConfig_redactionConfig_PiiEntityType;
                requestRedactionConfigIsNull = false;
            }
             // determine if request.RedactionConfig should be set to null
            if (requestRedactionConfigIsNull)
            {
                request.RedactionConfig = null;
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
        
        private Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "StartPiiEntitiesDetectionJob");
            try
            {
                #if DESKTOP
                return client.StartPiiEntitiesDetectionJob(request);
                #elif CORECLR
                return client.StartPiiEntitiesDetectionJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public Amazon.Comprehend.Model.InputDataConfig InputDataConfig { get; set; }
            public System.String JobName { get; set; }
            public Amazon.Comprehend.LanguageCode LanguageCode { get; set; }
            public Amazon.Comprehend.PiiEntitiesDetectionMode Mode { get; set; }
            public Amazon.Comprehend.Model.OutputDataConfig OutputDataConfig { get; set; }
            public System.String RedactionConfig_MaskCharacter { get; set; }
            public Amazon.Comprehend.PiiEntitiesDetectionMaskMode RedactionConfig_MaskMode { get; set; }
            public List<System.String> RedactionConfig_PiiEntityType { get; set; }
            public System.Func<Amazon.Comprehend.Model.StartPiiEntitiesDetectionJobResponse, StartCOMPPiiEntitiesDetectionJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
