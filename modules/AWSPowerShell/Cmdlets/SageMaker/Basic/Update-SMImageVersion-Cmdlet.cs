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
    /// Updates the properties of a SageMaker image version.
    /// </summary>
    [Cmdlet("Update", "SMImageVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateImageVersion API operation.", Operation = new[] {"UpdateImageVersion"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateImageVersionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateImageVersionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateImageVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMImageVersionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>The alias of the image version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter AliasesToAdd
        /// <summary>
        /// <para>
        /// <para>A list of aliases to add.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AliasesToAdd { get; set; }
        #endregion
        
        #region Parameter AliasesToDelete
        /// <summary>
        /// <para>
        /// <para>A list of aliases to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AliasesToDelete { get; set; }
        #endregion
        
        #region Parameter Horovod
        /// <summary>
        /// <para>
        /// <para>Indicates Horovod compatibility.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Horovod { get; set; }
        #endregion
        
        #region Parameter ImageName
        /// <summary>
        /// <para>
        /// <para>The name of the image.</para>
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
        public System.String ImageName { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// <para>Indicates SageMaker job type compatibility.</para><ul><li><para><c>TRAINING</c>: The image version is compatible with SageMaker training jobs.</para></li><li><para><c>INFERENCE</c>: The image version is compatible with SageMaker inference jobs.</para></li><li><para><c>NOTEBOOK_KERNEL</c>: The image version is compatible with SageMaker notebook kernels.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.JobType")]
        public Amazon.SageMaker.JobType JobType { get; set; }
        #endregion
        
        #region Parameter MLFramework
        /// <summary>
        /// <para>
        /// <para>The machine learning framework vended in the image version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MLFramework { get; set; }
        #endregion
        
        #region Parameter Processor
        /// <summary>
        /// <para>
        /// <para>Indicates CPU or GPU compatibility.</para><ul><li><para><c>CPU</c>: The image version is compatible with CPU.</para></li><li><para><c>GPU</c>: The image version is compatible with GPU.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.Processor")]
        public Amazon.SageMaker.Processor Processor { get; set; }
        #endregion
        
        #region Parameter ProgrammingLang
        /// <summary>
        /// <para>
        /// <para>The supported programming language and its version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProgrammingLang { get; set; }
        #endregion
        
        #region Parameter ReleaseNote
        /// <summary>
        /// <para>
        /// <para>The maintainer description of the image version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReleaseNotes")]
        public System.String ReleaseNote { get; set; }
        #endregion
        
        #region Parameter VendorGuidance
        /// <summary>
        /// <para>
        /// <para>The availability of the image version specified by the maintainer.</para><ul><li><para><c>NOT_PROVIDED</c>: The maintainers did not provide a status for image version stability.</para></li><li><para><c>STABLE</c>: The image version is stable.</para></li><li><para><c>TO_BE_ARCHIVED</c>: The image version is set to be archived. Custom image versions
        /// that are set to be archived are automatically archived after three months.</para></li><li><para><c>ARCHIVED</c>: The image version is archived. Archived image versions are not searchable
        /// and are no longer actively supported. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.VendorGuidance")]
        public Amazon.SageMaker.VendorGuidance VendorGuidance { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The version of the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageVersionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateImageVersionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateImageVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageVersionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ImageName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ImageName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ImageName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMImageVersion (UpdateImageVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateImageVersionResponse, UpdateSMImageVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ImageName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Alias = this.Alias;
            if (this.AliasesToAdd != null)
            {
                context.AliasesToAdd = new List<System.String>(this.AliasesToAdd);
            }
            if (this.AliasesToDelete != null)
            {
                context.AliasesToDelete = new List<System.String>(this.AliasesToDelete);
            }
            context.Horovod = this.Horovod;
            context.ImageName = this.ImageName;
            #if MODULAR
            if (this.ImageName == null && ParameterWasBound(nameof(this.ImageName)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobType = this.JobType;
            context.MLFramework = this.MLFramework;
            context.Processor = this.Processor;
            context.ProgrammingLang = this.ProgrammingLang;
            context.ReleaseNote = this.ReleaseNote;
            context.VendorGuidance = this.VendorGuidance;
            context.Version = this.Version;
            
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
            var request = new Amazon.SageMaker.Model.UpdateImageVersionRequest();
            
            if (cmdletContext.Alias != null)
            {
                request.Alias = cmdletContext.Alias;
            }
            if (cmdletContext.AliasesToAdd != null)
            {
                request.AliasesToAdd = cmdletContext.AliasesToAdd;
            }
            if (cmdletContext.AliasesToDelete != null)
            {
                request.AliasesToDelete = cmdletContext.AliasesToDelete;
            }
            if (cmdletContext.Horovod != null)
            {
                request.Horovod = cmdletContext.Horovod.Value;
            }
            if (cmdletContext.ImageName != null)
            {
                request.ImageName = cmdletContext.ImageName;
            }
            if (cmdletContext.JobType != null)
            {
                request.JobType = cmdletContext.JobType;
            }
            if (cmdletContext.MLFramework != null)
            {
                request.MLFramework = cmdletContext.MLFramework;
            }
            if (cmdletContext.Processor != null)
            {
                request.Processor = cmdletContext.Processor;
            }
            if (cmdletContext.ProgrammingLang != null)
            {
                request.ProgrammingLang = cmdletContext.ProgrammingLang;
            }
            if (cmdletContext.ReleaseNote != null)
            {
                request.ReleaseNotes = cmdletContext.ReleaseNote;
            }
            if (cmdletContext.VendorGuidance != null)
            {
                request.VendorGuidance = cmdletContext.VendorGuidance;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version.Value;
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
        
        private Amazon.SageMaker.Model.UpdateImageVersionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateImageVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateImageVersion");
            try
            {
                #if DESKTOP
                return client.UpdateImageVersion(request);
                #elif CORECLR
                return client.UpdateImageVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String Alias { get; set; }
            public List<System.String> AliasesToAdd { get; set; }
            public List<System.String> AliasesToDelete { get; set; }
            public System.Boolean? Horovod { get; set; }
            public System.String ImageName { get; set; }
            public Amazon.SageMaker.JobType JobType { get; set; }
            public System.String MLFramework { get; set; }
            public Amazon.SageMaker.Processor Processor { get; set; }
            public System.String ProgrammingLang { get; set; }
            public System.String ReleaseNote { get; set; }
            public Amazon.SageMaker.VendorGuidance VendorGuidance { get; set; }
            public System.Int32? Version { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateImageVersionResponse, UpdateSMImageVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageVersionArn;
        }
        
    }
}
