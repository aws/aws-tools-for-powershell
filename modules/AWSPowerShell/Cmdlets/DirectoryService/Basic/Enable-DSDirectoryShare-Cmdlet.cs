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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Shares a specified directory (<code>DirectoryId</code>) in your Amazon Web Services
    /// account (directory owner) with another Amazon Web Services account (directory consumer).
    /// With this operation you can use your directory from any Amazon Web Services account
    /// and from any Amazon VPC within an Amazon Web Services Region.
    /// 
    ///  
    /// <para>
    /// When you share your Managed Microsoft AD directory, Directory Service creates a shared
    /// directory in the directory consumer account. This shared directory contains the metadata
    /// to provide access to the directory within the directory owner account. The shared
    /// directory is visible in all VPCs in the directory consumer account.
    /// </para><para>
    /// The <code>ShareMethod</code> parameter determines whether the specified directory
    /// can be shared between Amazon Web Services accounts inside the same Amazon Web Services
    /// organization (<code>ORGANIZATIONS</code>). It also determines whether you can share
    /// the directory with any other Amazon Web Services account either inside or outside
    /// of the organization (<code>HANDSHAKE</code>).
    /// </para><para>
    /// The <code>ShareNotes</code> parameter is only used when <code>HANDSHAKE</code> is
    /// called, which sends a directory sharing request to the directory consumer. 
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "DSDirectoryShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Directory Service ShareDirectory API operation.", Operation = new[] {"ShareDirectory"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.ShareDirectoryResponse))]
    [AWSCmdletOutput("System.String or Amazon.DirectoryService.Model.ShareDirectoryResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DirectoryService.Model.ShareDirectoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableDSDirectoryShareCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>Identifier of the Managed Microsoft AD directory that you want to share with other
        /// Amazon Web Services accounts.</para>
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
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter ShareTarget_Id
        /// <summary>
        /// <para>
        /// <para>Identifier of the directory consumer account.</para>
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
        public System.String ShareTarget_Id { get; set; }
        #endregion
        
        #region Parameter ShareMethod
        /// <summary>
        /// <para>
        /// <para>The method used when sharing a directory to determine whether the directory should
        /// be shared within your Amazon Web Services organization (<code>ORGANIZATIONS</code>)
        /// or with any Amazon Web Services account by sending a directory sharing request (<code>HANDSHAKE</code>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DirectoryService.ShareMethod")]
        public Amazon.DirectoryService.ShareMethod ShareMethod { get; set; }
        #endregion
        
        #region Parameter ShareNote
        /// <summary>
        /// <para>
        /// <para>A directory share request that is sent by the directory owner to the directory consumer.
        /// The request includes a typed message to help the directory consumer administrator
        /// determine whether to approve or reject the share invitation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ShareNotes")]
        public System.String ShareNote { get; set; }
        #endregion
        
        #region Parameter ShareTarget_Type
        /// <summary>
        /// <para>
        /// <para>Type of identifier to be used in the <code>Id</code> field.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DirectoryService.TargetType")]
        public Amazon.DirectoryService.TargetType ShareTarget_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SharedDirectoryId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.ShareDirectoryResponse).
        /// Specifying the name of a property of type Amazon.DirectoryService.Model.ShareDirectoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SharedDirectoryId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DirectoryId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DirectoryId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DirectoryId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DSDirectoryShare (ShareDirectory)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.ShareDirectoryResponse, EnableDSDirectoryShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DirectoryId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShareMethod = this.ShareMethod;
            #if MODULAR
            if (this.ShareMethod == null && ParameterWasBound(nameof(this.ShareMethod)))
            {
                WriteWarning("You are passing $null as a value for parameter ShareMethod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShareNote = this.ShareNote;
            context.ShareTarget_Id = this.ShareTarget_Id;
            #if MODULAR
            if (this.ShareTarget_Id == null && ParameterWasBound(nameof(this.ShareTarget_Id)))
            {
                WriteWarning("You are passing $null as a value for parameter ShareTarget_Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShareTarget_Type = this.ShareTarget_Type;
            #if MODULAR
            if (this.ShareTarget_Type == null && ParameterWasBound(nameof(this.ShareTarget_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter ShareTarget_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectoryService.Model.ShareDirectoryRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.ShareMethod != null)
            {
                request.ShareMethod = cmdletContext.ShareMethod;
            }
            if (cmdletContext.ShareNote != null)
            {
                request.ShareNotes = cmdletContext.ShareNote;
            }
            
             // populate ShareTarget
            var requestShareTargetIsNull = true;
            request.ShareTarget = new Amazon.DirectoryService.Model.ShareTarget();
            System.String requestShareTarget_shareTarget_Id = null;
            if (cmdletContext.ShareTarget_Id != null)
            {
                requestShareTarget_shareTarget_Id = cmdletContext.ShareTarget_Id;
            }
            if (requestShareTarget_shareTarget_Id != null)
            {
                request.ShareTarget.Id = requestShareTarget_shareTarget_Id;
                requestShareTargetIsNull = false;
            }
            Amazon.DirectoryService.TargetType requestShareTarget_shareTarget_Type = null;
            if (cmdletContext.ShareTarget_Type != null)
            {
                requestShareTarget_shareTarget_Type = cmdletContext.ShareTarget_Type;
            }
            if (requestShareTarget_shareTarget_Type != null)
            {
                request.ShareTarget.Type = requestShareTarget_shareTarget_Type;
                requestShareTargetIsNull = false;
            }
             // determine if request.ShareTarget should be set to null
            if (requestShareTargetIsNull)
            {
                request.ShareTarget = null;
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
        
        private Amazon.DirectoryService.Model.ShareDirectoryResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.ShareDirectoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "ShareDirectory");
            try
            {
                #if DESKTOP
                return client.ShareDirectory(request);
                #elif CORECLR
                return client.ShareDirectoryAsync(request).GetAwaiter().GetResult();
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
            public System.String DirectoryId { get; set; }
            public Amazon.DirectoryService.ShareMethod ShareMethod { get; set; }
            public System.String ShareNote { get; set; }
            public System.String ShareTarget_Id { get; set; }
            public Amazon.DirectoryService.TargetType ShareTarget_Type { get; set; }
            public System.Func<Amazon.DirectoryService.Model.ShareDirectoryResponse, EnableDSDirectoryShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SharedDirectoryId;
        }
        
    }
}
