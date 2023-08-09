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
    /// Creates an Amazon SageMaker Model Card export job.
    /// </summary>
    [Cmdlet("New", "SMModelCardExportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateModelCardExportJob API operation.", Operation = new[] {"CreateModelCardExportJob"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateModelCardExportJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateModelCardExportJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateModelCardExportJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMModelCardExportJobCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter ModelCardExportJobName
        /// <summary>
        /// <para>
        /// <para>The name of the model card export job.</para>
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
        public System.String ModelCardExportJobName { get; set; }
        #endregion
        
        #region Parameter ModelCardName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the model card to export.</para>
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
        public System.String ModelCardName { get; set; }
        #endregion
        
        #region Parameter ModelCardVersion
        /// <summary>
        /// <para>
        /// <para>The version of the model card to export. If a version is not provided, then the latest
        /// version of the model card is exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ModelCardVersion { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 output path to export your model card PDF.</para>
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
        public System.String OutputConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelCardExportJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateModelCardExportJobResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateModelCardExportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelCardExportJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ModelCardName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ModelCardName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ModelCardName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelCardName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMModelCardExportJob (CreateModelCardExportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateModelCardExportJobResponse, NewSMModelCardExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ModelCardName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ModelCardExportJobName = this.ModelCardExportJobName;
            #if MODULAR
            if (this.ModelCardExportJobName == null && ParameterWasBound(nameof(this.ModelCardExportJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelCardExportJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelCardName = this.ModelCardName;
            #if MODULAR
            if (this.ModelCardName == null && ParameterWasBound(nameof(this.ModelCardName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelCardName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelCardVersion = this.ModelCardVersion;
            context.OutputConfig_S3OutputPath = this.OutputConfig_S3OutputPath;
            #if MODULAR
            if (this.OutputConfig_S3OutputPath == null && ParameterWasBound(nameof(this.OutputConfig_S3OutputPath)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_S3OutputPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.CreateModelCardExportJobRequest();
            
            if (cmdletContext.ModelCardExportJobName != null)
            {
                request.ModelCardExportJobName = cmdletContext.ModelCardExportJobName;
            }
            if (cmdletContext.ModelCardName != null)
            {
                request.ModelCardName = cmdletContext.ModelCardName;
            }
            if (cmdletContext.ModelCardVersion != null)
            {
                request.ModelCardVersion = cmdletContext.ModelCardVersion.Value;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMaker.Model.ModelCardExportOutputConfig();
            System.String requestOutputConfig_outputConfig_S3OutputPath = null;
            if (cmdletContext.OutputConfig_S3OutputPath != null)
            {
                requestOutputConfig_outputConfig_S3OutputPath = cmdletContext.OutputConfig_S3OutputPath;
            }
            if (requestOutputConfig_outputConfig_S3OutputPath != null)
            {
                request.OutputConfig.S3OutputPath = requestOutputConfig_outputConfig_S3OutputPath;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
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
        
        private Amazon.SageMaker.Model.CreateModelCardExportJobResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateModelCardExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateModelCardExportJob");
            try
            {
                #if DESKTOP
                return client.CreateModelCardExportJob(request);
                #elif CORECLR
                return client.CreateModelCardExportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ModelCardExportJobName { get; set; }
            public System.String ModelCardName { get; set; }
            public System.Int32? ModelCardVersion { get; set; }
            public System.String OutputConfig_S3OutputPath { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateModelCardExportJobResponse, NewSMModelCardExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelCardExportJobArn;
        }
        
    }
}
