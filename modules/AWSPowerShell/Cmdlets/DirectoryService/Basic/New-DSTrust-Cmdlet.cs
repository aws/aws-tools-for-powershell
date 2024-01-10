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
    /// Directory Service for Microsoft Active Directory allows you to configure trust relationships.
    /// For example, you can establish a trust between your Managed Microsoft AD directory,
    /// and your existing self-managed Microsoft Active Directory. This would allow you to
    /// provide users and groups access to resources in either domain, with a single set of
    /// credentials.
    /// 
    ///  
    /// <para>
    /// This action initiates the creation of the Amazon Web Services side of a trust relationship
    /// between an Managed Microsoft AD directory and an external domain. You can create either
    /// a forest trust or an external trust.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSTrust", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Directory Service CreateTrust API operation.", Operation = new[] {"CreateTrust"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.CreateTrustResponse))]
    [AWSCmdletOutput("System.String or Amazon.DirectoryService.Model.CreateTrustResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DirectoryService.Model.CreateTrustResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSTrustCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConditionalForwarderIpAddr
        /// <summary>
        /// <para>
        /// <para>The IP addresses of the remote DNS server associated with RemoteDomainName.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConditionalForwarderIpAddrs")]
        public System.String[] ConditionalForwarderIpAddr { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The Directory ID of the Managed Microsoft AD directory for which to establish the
        /// trust relationship.</para>
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
        
        #region Parameter RemoteDomainName
        /// <summary>
        /// <para>
        /// <para>The Fully Qualified Domain Name (FQDN) of the external domain for which to create
        /// the trust relationship.</para>
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
        public System.String RemoteDomainName { get; set; }
        #endregion
        
        #region Parameter SelectiveAuth
        /// <summary>
        /// <para>
        /// <para>Optional parameter to enable selective authentication for the trust.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectoryService.SelectiveAuth")]
        public Amazon.DirectoryService.SelectiveAuth SelectiveAuth { get; set; }
        #endregion
        
        #region Parameter TrustDirection
        /// <summary>
        /// <para>
        /// <para>The direction of the trust relationship.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DirectoryService.TrustDirection")]
        public Amazon.DirectoryService.TrustDirection TrustDirection { get; set; }
        #endregion
        
        #region Parameter TrustPassword
        /// <summary>
        /// <para>
        /// <para>The trust password. The must be the same password that was used when creating the
        /// trust relationship on the external domain.</para>
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
        public System.String TrustPassword { get; set; }
        #endregion
        
        #region Parameter TrustType
        /// <summary>
        /// <para>
        /// <para>The trust relationship type. <c>Forest</c> is the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectoryService.TrustType")]
        public Amazon.DirectoryService.TrustType TrustType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrustId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.CreateTrustResponse).
        /// Specifying the name of a property of type Amazon.DirectoryService.Model.CreateTrustResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrustId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSTrust (CreateTrust)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.CreateTrustResponse, NewDSTrustCmdlet>(Select) ??
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
            if (this.ConditionalForwarderIpAddr != null)
            {
                context.ConditionalForwarderIpAddr = new List<System.String>(this.ConditionalForwarderIpAddr);
            }
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RemoteDomainName = this.RemoteDomainName;
            #if MODULAR
            if (this.RemoteDomainName == null && ParameterWasBound(nameof(this.RemoteDomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter RemoteDomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SelectiveAuth = this.SelectiveAuth;
            context.TrustDirection = this.TrustDirection;
            #if MODULAR
            if (this.TrustDirection == null && ParameterWasBound(nameof(this.TrustDirection)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustDirection which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrustPassword = this.TrustPassword;
            #if MODULAR
            if (this.TrustPassword == null && ParameterWasBound(nameof(this.TrustPassword)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustPassword which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrustType = this.TrustType;
            
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
            var request = new Amazon.DirectoryService.Model.CreateTrustRequest();
            
            if (cmdletContext.ConditionalForwarderIpAddr != null)
            {
                request.ConditionalForwarderIpAddrs = cmdletContext.ConditionalForwarderIpAddr;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.RemoteDomainName != null)
            {
                request.RemoteDomainName = cmdletContext.RemoteDomainName;
            }
            if (cmdletContext.SelectiveAuth != null)
            {
                request.SelectiveAuth = cmdletContext.SelectiveAuth;
            }
            if (cmdletContext.TrustDirection != null)
            {
                request.TrustDirection = cmdletContext.TrustDirection;
            }
            if (cmdletContext.TrustPassword != null)
            {
                request.TrustPassword = cmdletContext.TrustPassword;
            }
            if (cmdletContext.TrustType != null)
            {
                request.TrustType = cmdletContext.TrustType;
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
        
        private Amazon.DirectoryService.Model.CreateTrustResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.CreateTrustRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "CreateTrust");
            try
            {
                #if DESKTOP
                return client.CreateTrust(request);
                #elif CORECLR
                return client.CreateTrustAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ConditionalForwarderIpAddr { get; set; }
            public System.String DirectoryId { get; set; }
            public System.String RemoteDomainName { get; set; }
            public Amazon.DirectoryService.SelectiveAuth SelectiveAuth { get; set; }
            public Amazon.DirectoryService.TrustDirection TrustDirection { get; set; }
            public System.String TrustPassword { get; set; }
            public Amazon.DirectoryService.TrustType TrustType { get; set; }
            public System.Func<Amazon.DirectoryService.Model.CreateTrustResponse, NewDSTrustCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrustId;
        }
        
    }
}
