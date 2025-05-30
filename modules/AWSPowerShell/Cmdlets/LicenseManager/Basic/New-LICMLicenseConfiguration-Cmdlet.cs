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
using System.Threading;
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Creates a license configuration.
    /// 
    ///  
    /// <para>
    /// A license configuration is an abstraction of a customer license agreement that can
    /// be consumed and enforced by License Manager. Components include specifications for
    /// the license type (licensing by instance, socket, CPU, or vCPU), allowed tenancy (shared
    /// tenancy, Dedicated Instance, Dedicated Host, or all of these), license affinity to
    /// host (how long a license must be associated with a host), and the number of licenses
    /// purchased and used.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LICMLicenseConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS License Manager CreateLicenseConfiguration API operation.", Operation = new[] {"CreateLicenseConfiguration"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLICMLicenseConfigurationCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description of the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisassociateWhenNotFound
        /// <summary>
        /// <para>
        /// <para>When true, disassociates a resource when software is uninstalled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisassociateWhenNotFound { get; set; }
        #endregion
        
        #region Parameter LicenseCount
        /// <summary>
        /// <para>
        /// <para>Number of licenses managed by the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? LicenseCount { get; set; }
        #endregion
        
        #region Parameter LicenseCountHardLimit
        /// <summary>
        /// <para>
        /// <para>Indicates whether hard or soft license enforcement is used. Exceeding a hard limit
        /// blocks the launch of new instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LicenseCountHardLimit { get; set; }
        #endregion
        
        #region Parameter LicenseCountingType
        /// <summary>
        /// <para>
        /// <para>Dimension used to track the license inventory.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LicenseManager.LicenseCountingType")]
        public Amazon.LicenseManager.LicenseCountingType LicenseCountingType { get; set; }
        #endregion
        
        #region Parameter LicenseRule
        /// <summary>
        /// <para>
        /// <para>License rules. The syntax is #name=value (for example, #allowedTenancy=EC2-DedicatedHost).
        /// The available rules vary by dimension, as follows.</para><ul><li><para><c>Cores</c> dimension: <c>allowedTenancy</c> | <c>licenseAffinityToHost</c> | <c>maximumCores</c>
        /// | <c>minimumCores</c></para></li><li><para><c>Instances</c> dimension: <c>allowedTenancy</c> | <c>maximumVcpus</c> | <c>minimumVcpus</c></para></li><li><para><c>Sockets</c> dimension: <c>allowedTenancy</c> | <c>licenseAffinityToHost</c> |
        /// <c>maximumSockets</c> | <c>minimumSockets</c></para></li><li><para><c>vCPUs</c> dimension: <c>allowedTenancy</c> | <c>honorVcpuOptimization</c> | <c>maximumVcpus</c>
        /// | <c>minimumVcpus</c></para></li></ul><para>The unit for <c>licenseAffinityToHost</c> is days and the range is 1 to 180. The possible
        /// values for <c>allowedTenancy</c> are <c>EC2-Default</c>, <c>EC2-DedicatedHost</c>,
        /// and <c>EC2-DedicatedInstance</c>. The possible values for <c>honorVcpuOptimization</c>
        /// are <c>True</c> and <c>False</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LicenseRules")]
        public System.String[] LicenseRule { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the license configuration.</para>
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
        
        #region Parameter ProductInformationList
        /// <summary>
        /// <para>
        /// <para>Product information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LicenseManager.Model.ProductInformation[] ProductInformationList { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to add to the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.LicenseManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LicenseConfigurationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LicenseConfigurationArn";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LICMLicenseConfiguration (CreateLicenseConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse, NewLICMLicenseConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DisassociateWhenNotFound = this.DisassociateWhenNotFound;
            context.LicenseCount = this.LicenseCount;
            context.LicenseCountHardLimit = this.LicenseCountHardLimit;
            context.LicenseCountingType = this.LicenseCountingType;
            #if MODULAR
            if (this.LicenseCountingType == null && ParameterWasBound(nameof(this.LicenseCountingType)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseCountingType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LicenseRule != null)
            {
                context.LicenseRule = new List<System.String>(this.LicenseRule);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ProductInformationList != null)
            {
                context.ProductInformationList = new List<Amazon.LicenseManager.Model.ProductInformation>(this.ProductInformationList);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.LicenseManager.Model.Tag>(this.Tag);
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
            var request = new Amazon.LicenseManager.Model.CreateLicenseConfigurationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisassociateWhenNotFound != null)
            {
                request.DisassociateWhenNotFound = cmdletContext.DisassociateWhenNotFound.Value;
            }
            if (cmdletContext.LicenseCount != null)
            {
                request.LicenseCount = cmdletContext.LicenseCount.Value;
            }
            if (cmdletContext.LicenseCountHardLimit != null)
            {
                request.LicenseCountHardLimit = cmdletContext.LicenseCountHardLimit.Value;
            }
            if (cmdletContext.LicenseCountingType != null)
            {
                request.LicenseCountingType = cmdletContext.LicenseCountingType;
            }
            if (cmdletContext.LicenseRule != null)
            {
                request.LicenseRules = cmdletContext.LicenseRule;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProductInformationList != null)
            {
                request.ProductInformationList = cmdletContext.ProductInformationList;
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
        
        private Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.CreateLicenseConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "CreateLicenseConfiguration");
            try
            {
                return client.CreateLicenseConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DisassociateWhenNotFound { get; set; }
            public System.Int64? LicenseCount { get; set; }
            public System.Boolean? LicenseCountHardLimit { get; set; }
            public Amazon.LicenseManager.LicenseCountingType LicenseCountingType { get; set; }
            public List<System.String> LicenseRule { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.LicenseManager.Model.ProductInformation> ProductInformationList { get; set; }
            public List<Amazon.LicenseManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse, NewLICMLicenseConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LicenseConfigurationArn;
        }
        
    }
}
