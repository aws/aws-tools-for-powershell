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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Creates an AD Connector to connect to a self-managed directory.
    /// 
    ///  
    /// <para>
    /// Before you call <c>ConnectDirectory</c>, ensure that all of the required permissions
    /// have been explicitly granted through a policy. For details about what permissions
    /// are required to run the <c>ConnectDirectory</c> operation, see <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/UsingWithDS_IAM_ResourcePermissions.html">Directory
    /// Service API Permissions: Actions, Resources, and Conditions Reference</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Connect", "DSDirectory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Directory Service ConnectDirectory API operation.", Operation = new[] {"ConnectDirectory"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.ConnectDirectoryResponse))]
    [AWSCmdletOutput("System.String or Amazon.DirectoryService.Model.ConnectDirectoryResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DirectoryService.Model.ConnectDirectoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConnectDSDirectoryCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectSettings_CustomerDnsIp
        /// <summary>
        /// <para>
        /// <para>A list of one or more IP addresses of DNS servers or domain controllers in your self-managed
        /// directory.</para>
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
        [Alias("ConnectSettings_CustomerDnsIps")]
        public System.String[] ConnectSettings_CustomerDnsIp { get; set; }
        #endregion
        
        #region Parameter ConnectSettings_CustomerUserName
        /// <summary>
        /// <para>
        /// <para>The user name of an account in your self-managed directory that is used to connect
        /// to the directory. This account must have the following permissions:</para><ul><li><para>Read users and groups</para></li><li><para>Create computer objects</para></li><li><para>Join computers to the domain</para></li></ul>
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
        public System.String ConnectSettings_CustomerUserName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The fully qualified name of your self-managed directory, such as <c>corp.example.com</c>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password for your self-managed user account.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter ShortName
        /// <summary>
        /// <para>
        /// <para>The NetBIOS name of your self-managed directory, such as <c>CORP</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShortName { get; set; }
        #endregion
        
        #region Parameter Size
        /// <summary>
        /// <para>
        /// <para>The size of the directory.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DirectoryService.DirectorySize")]
        public Amazon.DirectoryService.DirectorySize Size { get; set; }
        #endregion
        
        #region Parameter ConnectSettings_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet identifiers in the VPC in which the AD Connector is created.</para>
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
        [Alias("ConnectSettings_SubnetIds")]
        public System.String[] ConnectSettings_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to AD Connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DirectoryService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ConnectSettings_VpcId
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC in which the AD Connector is created.</para>
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
        public System.String ConnectSettings_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DirectoryId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.ConnectDirectoryResponse).
        /// Specifying the name of a property of type Amazon.DirectoryService.Model.ConnectDirectoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DirectoryId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-DSDirectory (ConnectDirectory)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.ConnectDirectoryResponse, ConnectDSDirectoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ConnectSettings_CustomerDnsIp != null)
            {
                context.ConnectSettings_CustomerDnsIp = new List<System.String>(this.ConnectSettings_CustomerDnsIp);
            }
            #if MODULAR
            if (this.ConnectSettings_CustomerDnsIp == null && ParameterWasBound(nameof(this.ConnectSettings_CustomerDnsIp)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectSettings_CustomerDnsIp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectSettings_CustomerUserName = this.ConnectSettings_CustomerUserName;
            #if MODULAR
            if (this.ConnectSettings_CustomerUserName == null && ParameterWasBound(nameof(this.ConnectSettings_CustomerUserName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectSettings_CustomerUserName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ConnectSettings_SubnetId != null)
            {
                context.ConnectSettings_SubnetId = new List<System.String>(this.ConnectSettings_SubnetId);
            }
            #if MODULAR
            if (this.ConnectSettings_SubnetId == null && ParameterWasBound(nameof(this.ConnectSettings_SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectSettings_SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectSettings_VpcId = this.ConnectSettings_VpcId;
            #if MODULAR
            if (this.ConnectSettings_VpcId == null && ParameterWasBound(nameof(this.ConnectSettings_VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectSettings_VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Password = this.Password;
            #if MODULAR
            if (this.Password == null && ParameterWasBound(nameof(this.Password)))
            {
                WriteWarning("You are passing $null as a value for parameter Password which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShortName = this.ShortName;
            context.Size = this.Size;
            #if MODULAR
            if (this.Size == null && ParameterWasBound(nameof(this.Size)))
            {
                WriteWarning("You are passing $null as a value for parameter Size which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DirectoryService.Model.Tag>(this.Tag);
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
            var request = new Amazon.DirectoryService.Model.ConnectDirectoryRequest();
            
            
             // populate ConnectSettings
            var requestConnectSettingsIsNull = true;
            request.ConnectSettings = new Amazon.DirectoryService.Model.DirectoryConnectSettings();
            List<System.String> requestConnectSettings_connectSettings_CustomerDnsIp = null;
            if (cmdletContext.ConnectSettings_CustomerDnsIp != null)
            {
                requestConnectSettings_connectSettings_CustomerDnsIp = cmdletContext.ConnectSettings_CustomerDnsIp;
            }
            if (requestConnectSettings_connectSettings_CustomerDnsIp != null)
            {
                request.ConnectSettings.CustomerDnsIps = requestConnectSettings_connectSettings_CustomerDnsIp;
                requestConnectSettingsIsNull = false;
            }
            System.String requestConnectSettings_connectSettings_CustomerUserName = null;
            if (cmdletContext.ConnectSettings_CustomerUserName != null)
            {
                requestConnectSettings_connectSettings_CustomerUserName = cmdletContext.ConnectSettings_CustomerUserName;
            }
            if (requestConnectSettings_connectSettings_CustomerUserName != null)
            {
                request.ConnectSettings.CustomerUserName = requestConnectSettings_connectSettings_CustomerUserName;
                requestConnectSettingsIsNull = false;
            }
            List<System.String> requestConnectSettings_connectSettings_SubnetId = null;
            if (cmdletContext.ConnectSettings_SubnetId != null)
            {
                requestConnectSettings_connectSettings_SubnetId = cmdletContext.ConnectSettings_SubnetId;
            }
            if (requestConnectSettings_connectSettings_SubnetId != null)
            {
                request.ConnectSettings.SubnetIds = requestConnectSettings_connectSettings_SubnetId;
                requestConnectSettingsIsNull = false;
            }
            System.String requestConnectSettings_connectSettings_VpcId = null;
            if (cmdletContext.ConnectSettings_VpcId != null)
            {
                requestConnectSettings_connectSettings_VpcId = cmdletContext.ConnectSettings_VpcId;
            }
            if (requestConnectSettings_connectSettings_VpcId != null)
            {
                request.ConnectSettings.VpcId = requestConnectSettings_connectSettings_VpcId;
                requestConnectSettingsIsNull = false;
            }
             // determine if request.ConnectSettings should be set to null
            if (requestConnectSettingsIsNull)
            {
                request.ConnectSettings = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.ShortName != null)
            {
                request.ShortName = cmdletContext.ShortName;
            }
            if (cmdletContext.Size != null)
            {
                request.Size = cmdletContext.Size;
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
        
        private Amazon.DirectoryService.Model.ConnectDirectoryResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.ConnectDirectoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "ConnectDirectory");
            try
            {
                #if DESKTOP
                return client.ConnectDirectory(request);
                #elif CORECLR
                return client.ConnectDirectoryAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ConnectSettings_CustomerDnsIp { get; set; }
            public System.String ConnectSettings_CustomerUserName { get; set; }
            public List<System.String> ConnectSettings_SubnetId { get; set; }
            public System.String ConnectSettings_VpcId { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String Password { get; set; }
            public System.String ShortName { get; set; }
            public Amazon.DirectoryService.DirectorySize Size { get; set; }
            public List<Amazon.DirectoryService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.DirectoryService.Model.ConnectDirectoryResponse, ConnectDSDirectoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DirectoryId;
        }
        
    }
}
