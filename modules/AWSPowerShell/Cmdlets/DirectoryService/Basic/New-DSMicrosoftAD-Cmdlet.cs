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
    /// Creates a Microsoft AD directory in the Amazon Web Services Cloud. For more information,
    /// see <a href="https://docs.aws.amazon.com/directoryservice/latest/admin-guide/directory_microsoft_ad.html">Managed
    /// Microsoft AD</a> in the <i>Directory Service Admin Guide</i>.
    /// 
    ///  
    /// <para>
    /// Before you call <i>CreateMicrosoftAD</i>, ensure that all of the required permissions
    /// have been explicitly granted through a policy. For details about what permissions
    /// are required to run the <i>CreateMicrosoftAD</i> operation, see <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/UsingWithDS_IAM_ResourcePermissions.html">Directory
    /// Service API Permissions: Actions, Resources, and Conditions Reference</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSMicrosoftAD", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Directory Service CreateMicrosoftAD API operation.", Operation = new[] {"CreateMicrosoftAD"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.CreateMicrosoftADResponse))]
    [AWSCmdletOutput("System.String or Amazon.DirectoryService.Model.CreateMicrosoftADResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DirectoryService.Model.CreateMicrosoftADResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSMicrosoftADCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the directory. This label will appear on the Amazon Web Services
        /// console <c>Directory Details</c> page after the directory is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Edition
        /// <summary>
        /// <para>
        /// <para>Managed Microsoft AD is available in two editions: <c>Standard</c> and <c>Enterprise</c>.
        /// <c>Enterprise</c> is the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectoryService.DirectoryEdition")]
        public Amazon.DirectoryService.DirectoryEdition Edition { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name for the Managed Microsoft AD directory, such as <c>corp.example.com</c>.
        /// This name will resolve inside your VPC only. It does not need to be publicly resolvable.</para>
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
        /// <para>The password for the default administrative user named <c>Admin</c>.</para><para>If you need to change the password for the administrator account, you can use the
        /// <a>ResetUserPassword</a> API call.</para>
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
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter ShortName
        /// <summary>
        /// <para>
        /// <para>The NetBIOS name for your domain, such as <c>CORP</c>. If you don't specify a NetBIOS
        /// name, it will default to the first part of your directory DNS. For example, <c>CORP</c>
        /// for the directory DNS <c>corp.example.com</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShortName { get; set; }
        #endregion
        
        #region Parameter VpcSettings_SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets for the directory servers. The two subnets must be
        /// in different Availability Zones. Directory Service creates a directory server and
        /// a DNS server in each of these subnets.</para>
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
        [Alias("VpcSettings_SubnetIds")]
        public System.String[] VpcSettings_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the Managed Microsoft AD directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DirectoryService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VpcSettings_VpcId
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC in which to create the directory.</para>
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
        public System.String VpcSettings_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DirectoryId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.CreateMicrosoftADResponse).
        /// Specifying the name of a property of type Amazon.DirectoryService.Model.CreateMicrosoftADResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSMicrosoftAD (CreateMicrosoftAD)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.CreateMicrosoftADResponse, NewDSMicrosoftADCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.Edition = this.Edition;
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
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DirectoryService.Model.Tag>(this.Tag);
            }
            if (this.VpcSettings_SubnetId != null)
            {
                context.VpcSettings_SubnetId = new List<System.String>(this.VpcSettings_SubnetId);
            }
            #if MODULAR
            if (this.VpcSettings_SubnetId == null && ParameterWasBound(nameof(this.VpcSettings_SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcSettings_SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpcSettings_VpcId = this.VpcSettings_VpcId;
            #if MODULAR
            if (this.VpcSettings_VpcId == null && ParameterWasBound(nameof(this.VpcSettings_VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcSettings_VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectoryService.Model.CreateMicrosoftADRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Edition != null)
            {
                request.Edition = cmdletContext.Edition;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VpcSettings
            var requestVpcSettingsIsNull = true;
            request.VpcSettings = new Amazon.DirectoryService.Model.DirectoryVpcSettings();
            List<System.String> requestVpcSettings_vpcSettings_SubnetId = null;
            if (cmdletContext.VpcSettings_SubnetId != null)
            {
                requestVpcSettings_vpcSettings_SubnetId = cmdletContext.VpcSettings_SubnetId;
            }
            if (requestVpcSettings_vpcSettings_SubnetId != null)
            {
                request.VpcSettings.SubnetIds = requestVpcSettings_vpcSettings_SubnetId;
                requestVpcSettingsIsNull = false;
            }
            System.String requestVpcSettings_vpcSettings_VpcId = null;
            if (cmdletContext.VpcSettings_VpcId != null)
            {
                requestVpcSettings_vpcSettings_VpcId = cmdletContext.VpcSettings_VpcId;
            }
            if (requestVpcSettings_vpcSettings_VpcId != null)
            {
                request.VpcSettings.VpcId = requestVpcSettings_vpcSettings_VpcId;
                requestVpcSettingsIsNull = false;
            }
             // determine if request.VpcSettings should be set to null
            if (requestVpcSettingsIsNull)
            {
                request.VpcSettings = null;
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
        
        private Amazon.DirectoryService.Model.CreateMicrosoftADResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.CreateMicrosoftADRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "CreateMicrosoftAD");
            try
            {
                #if DESKTOP
                return client.CreateMicrosoftAD(request);
                #elif CORECLR
                return client.CreateMicrosoftADAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.DirectoryService.DirectoryEdition Edition { get; set; }
            public System.String Name { get; set; }
            public System.String Password { get; set; }
            public System.String ShortName { get; set; }
            public List<Amazon.DirectoryService.Model.Tag> Tag { get; set; }
            public List<System.String> VpcSettings_SubnetId { get; set; }
            public System.String VpcSettings_VpcId { get; set; }
            public System.Func<Amazon.DirectoryService.Model.CreateMicrosoftADResponse, NewDSMicrosoftADCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DirectoryId;
        }
        
    }
}
