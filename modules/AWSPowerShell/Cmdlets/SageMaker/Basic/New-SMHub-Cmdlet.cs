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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Create a hub.
    /// </summary>
    [Cmdlet("New", "SMHub", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateHub API operation.", Operation = new[] {"CreateHub"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateHubResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateHubResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateHubResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMHubCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HubDescription
        /// <summary>
        /// <para>
        /// <para>A description of the hub.</para>
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
        public System.String HubDescription { get; set; }
        #endregion
        
        #region Parameter HubDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the hub.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HubDisplayName { get; set; }
        #endregion
        
        #region Parameter HubName
        /// <summary>
        /// <para>
        /// <para>The name of the hub to create.</para>
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
        public System.String HubName { get; set; }
        #endregion
        
        #region Parameter HubSearchKeyword
        /// <summary>
        /// <para>
        /// <para>The searchable keywords for the hub.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HubSearchKeywords")]
        public System.String[] HubSearchKeyword { get; set; }
        #endregion
        
        #region Parameter S3StorageConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket prefix for hosting hub content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3StorageConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Any tags to associate with the hub.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HubArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateHubResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateHubResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HubArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HubName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMHub (CreateHub)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateHubResponse, NewSMHubCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HubDescription = this.HubDescription;
            #if MODULAR
            if (this.HubDescription == null && ParameterWasBound(nameof(this.HubDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter HubDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HubDisplayName = this.HubDisplayName;
            context.HubName = this.HubName;
            #if MODULAR
            if (this.HubName == null && ParameterWasBound(nameof(this.HubName)))
            {
                WriteWarning("You are passing $null as a value for parameter HubName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.HubSearchKeyword != null)
            {
                context.HubSearchKeyword = new List<System.String>(this.HubSearchKeyword);
            }
            context.S3StorageConfig_S3OutputPath = this.S3StorageConfig_S3OutputPath;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateHubRequest();
            
            if (cmdletContext.HubDescription != null)
            {
                request.HubDescription = cmdletContext.HubDescription;
            }
            if (cmdletContext.HubDisplayName != null)
            {
                request.HubDisplayName = cmdletContext.HubDisplayName;
            }
            if (cmdletContext.HubName != null)
            {
                request.HubName = cmdletContext.HubName;
            }
            if (cmdletContext.HubSearchKeyword != null)
            {
                request.HubSearchKeywords = cmdletContext.HubSearchKeyword;
            }
            
             // populate S3StorageConfig
            var requestS3StorageConfigIsNull = true;
            request.S3StorageConfig = new Amazon.SageMaker.Model.HubS3StorageConfig();
            System.String requestS3StorageConfig_s3StorageConfig_S3OutputPath = null;
            if (cmdletContext.S3StorageConfig_S3OutputPath != null)
            {
                requestS3StorageConfig_s3StorageConfig_S3OutputPath = cmdletContext.S3StorageConfig_S3OutputPath;
            }
            if (requestS3StorageConfig_s3StorageConfig_S3OutputPath != null)
            {
                request.S3StorageConfig.S3OutputPath = requestS3StorageConfig_s3StorageConfig_S3OutputPath;
                requestS3StorageConfigIsNull = false;
            }
             // determine if request.S3StorageConfig should be set to null
            if (requestS3StorageConfigIsNull)
            {
                request.S3StorageConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateHubResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateHubRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateHub");
            try
            {
                #if DESKTOP
                return client.CreateHub(request);
                #elif CORECLR
                return client.CreateHubAsync(request).GetAwaiter().GetResult();
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
            public System.String HubDescription { get; set; }
            public System.String HubDisplayName { get; set; }
            public System.String HubName { get; set; }
            public List<System.String> HubSearchKeyword { get; set; }
            public System.String S3StorageConfig_S3OutputPath { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateHubResponse, NewSMHubCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HubArn;
        }
        
    }
}
