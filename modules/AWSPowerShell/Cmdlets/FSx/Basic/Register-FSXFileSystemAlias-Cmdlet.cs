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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Use this action to associate one or more Domain Name Server (DNS) aliases with an
    /// existing Amazon FSx for Windows File Server file system. A file system can have a
    /// maximum of 50 DNS aliases associated with it at any one time. If you try to associate
    /// a DNS alias that is already associated with the file system, FSx takes no action on
    /// that alias in the request. For more information, see <a href="https://docs.aws.amazon.com/fsx/latest/WindowsGuide/managing-dns-aliases.html">Working
    /// with DNS Aliases</a> and <a href="https://docs.aws.amazon.com/fsx/latest/WindowsGuide/walkthrough05-file-system-custom-CNAME.html">Walkthrough
    /// 5: Using DNS aliases to access your file system</a>, including additional steps you
    /// must take to be able to access your file system using a DNS alias.
    /// 
    ///  
    /// <para>
    /// The system response shows the DNS aliases that Amazon FSx is attempting to associate
    /// with the file system. Use the API operation to monitor the status of the aliases Amazon
    /// FSx is associating with the file system.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "FSXFileSystemAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.Alias")]
    [AWSCmdlet("Calls the Amazon FSx AssociateFileSystemAliases API operation.", Operation = new[] {"AssociateFileSystemAliases"}, SelectReturnType = typeof(Amazon.FSx.Model.AssociateFileSystemAliasesResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.Alias or Amazon.FSx.Model.AssociateFileSystemAliasesResponse",
        "This cmdlet returns a collection of Amazon.FSx.Model.Alias objects.",
        "The service call response (type Amazon.FSx.Model.AssociateFileSystemAliasesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterFSXFileSystemAliasCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>An array of one or more DNS alias names to associate with the file system. The alias
        /// name has to comply with the following formatting requirements:</para><ul><li><para>Formatted as a fully-qualified domain name (FQDN), <i><c>hostname.domain</c></i>,
        /// for example, <c>accounting.corp.example.com</c>.</para></li><li><para>Can contain alphanumeric characters and the hyphen (-).</para></li><li><para>Cannot start or end with a hyphen.</para></li><li><para>Can start with a numeric.</para></li></ul><para>For DNS alias names, Amazon FSx stores alphabetic characters as lowercase letters
        /// (a-z), regardless of how you specify them: as uppercase letters, lowercase letters,
        /// or the corresponding letters in escape codes.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Aliases")]
        public System.String[] Alias { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>Specifies the file system with which you want to associate one or more DNS aliases.</para>
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
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Aliases'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.AssociateFileSystemAliasesResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.AssociateFileSystemAliasesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Aliases";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-FSXFileSystemAlias (AssociateFileSystemAliases)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.AssociateFileSystemAliasesResponse, RegisterFSXFileSystemAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Alias != null)
            {
                context.Alias = new List<System.String>(this.Alias);
            }
            #if MODULAR
            if (this.Alias == null && ParameterWasBound(nameof(this.Alias)))
            {
                WriteWarning("You are passing $null as a value for parameter Alias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FSx.Model.AssociateFileSystemAliasesRequest();
            
            if (cmdletContext.Alias != null)
            {
                request.Aliases = cmdletContext.Alias;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
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
        
        private Amazon.FSx.Model.AssociateFileSystemAliasesResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.AssociateFileSystemAliasesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "AssociateFileSystemAliases");
            try
            {
                #if DESKTOP
                return client.AssociateFileSystemAliases(request);
                #elif CORECLR
                return client.AssociateFileSystemAliasesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Alias { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String FileSystemId { get; set; }
            public System.Func<Amazon.FSx.Model.AssociateFileSystemAliasesResponse, RegisterFSXFileSystemAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Aliases;
        }
        
    }
}
