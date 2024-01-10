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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Creates or updates an Amazon EMR block public access configuration for your Amazon
    /// Web Services account in the current Region. For more information see <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/configure-block-public-access.html">Configure
    /// Block Public Access for Amazon EMR</a> in the <i>Amazon EMR Management Guide</i>.
    /// </summary>
    [Cmdlet("Write", "EMRBlockPublicAccessConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce PutBlockPublicAccessConfiguration API operation.", Operation = new[] {"PutBlockPublicAccessConfiguration"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.PutBlockPublicAccessConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticMapReduce.Model.PutBlockPublicAccessConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticMapReduce.Model.PutBlockPublicAccessConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteEMRBlockPublicAccessConfigurationCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BlockPublicAccessConfiguration_BlockPublicSecurityGroupRule
        /// <summary>
        /// <para>
        /// <para>Indicates whether Amazon EMR block public access is enabled (<c>true</c>) or disabled
        /// (<c>false</c>). By default, the value is <c>false</c> for accounts that have created
        /// Amazon EMR clusters before July 2019. For accounts created after this, the default
        /// is <c>true</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("BlockPublicAccessConfiguration_BlockPublicSecurityGroupRules")]
        public System.Boolean? BlockPublicAccessConfiguration_BlockPublicSecurityGroupRule { get; set; }
        #endregion
        
        #region Parameter BlockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange
        /// <summary>
        /// <para>
        /// <para>Specifies ports and port ranges that are permitted to have security group rules that
        /// allow inbound traffic from all public sources. For example, if Port 23 (Telnet) is
        /// specified for <c>PermittedPublicSecurityGroupRuleRanges</c>, Amazon EMR allows cluster
        /// creation if a security group associated with the cluster has a rule that allows inbound
        /// traffic on Port 23 from IPv4 0.0.0.0/0 or IPv6 port ::/0 as the source.</para><para>By default, Port 22, which is used for SSH access to the cluster Amazon EC2 instances,
        /// is in the list of <c>PermittedPublicSecurityGroupRuleRanges</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRanges")]
        public Amazon.ElasticMapReduce.Model.PortRange[] BlockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.PutBlockPublicAccessConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EMRBlockPublicAccessConfiguration (PutBlockPublicAccessConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.PutBlockPublicAccessConfigurationResponse, WriteEMRBlockPublicAccessConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BlockPublicAccessConfiguration_BlockPublicSecurityGroupRule = this.BlockPublicAccessConfiguration_BlockPublicSecurityGroupRule;
            #if MODULAR
            if (this.BlockPublicAccessConfiguration_BlockPublicSecurityGroupRule == null && ParameterWasBound(nameof(this.BlockPublicAccessConfiguration_BlockPublicSecurityGroupRule)))
            {
                WriteWarning("You are passing $null as a value for parameter BlockPublicAccessConfiguration_BlockPublicSecurityGroupRule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.BlockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange != null)
            {
                context.BlockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange = new List<Amazon.ElasticMapReduce.Model.PortRange>(this.BlockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange);
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
            var request = new Amazon.ElasticMapReduce.Model.PutBlockPublicAccessConfigurationRequest();
            
            
             // populate BlockPublicAccessConfiguration
            var requestBlockPublicAccessConfigurationIsNull = true;
            request.BlockPublicAccessConfiguration = new Amazon.ElasticMapReduce.Model.BlockPublicAccessConfiguration();
            System.Boolean? requestBlockPublicAccessConfiguration_blockPublicAccessConfiguration_BlockPublicSecurityGroupRule = null;
            if (cmdletContext.BlockPublicAccessConfiguration_BlockPublicSecurityGroupRule != null)
            {
                requestBlockPublicAccessConfiguration_blockPublicAccessConfiguration_BlockPublicSecurityGroupRule = cmdletContext.BlockPublicAccessConfiguration_BlockPublicSecurityGroupRule.Value;
            }
            if (requestBlockPublicAccessConfiguration_blockPublicAccessConfiguration_BlockPublicSecurityGroupRule != null)
            {
                request.BlockPublicAccessConfiguration.BlockPublicSecurityGroupRules = requestBlockPublicAccessConfiguration_blockPublicAccessConfiguration_BlockPublicSecurityGroupRule.Value;
                requestBlockPublicAccessConfigurationIsNull = false;
            }
            List<Amazon.ElasticMapReduce.Model.PortRange> requestBlockPublicAccessConfiguration_blockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange = null;
            if (cmdletContext.BlockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange != null)
            {
                requestBlockPublicAccessConfiguration_blockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange = cmdletContext.BlockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange;
            }
            if (requestBlockPublicAccessConfiguration_blockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange != null)
            {
                request.BlockPublicAccessConfiguration.PermittedPublicSecurityGroupRuleRanges = requestBlockPublicAccessConfiguration_blockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange;
                requestBlockPublicAccessConfigurationIsNull = false;
            }
             // determine if request.BlockPublicAccessConfiguration should be set to null
            if (requestBlockPublicAccessConfigurationIsNull)
            {
                request.BlockPublicAccessConfiguration = null;
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
        
        private Amazon.ElasticMapReduce.Model.PutBlockPublicAccessConfigurationResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.PutBlockPublicAccessConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "PutBlockPublicAccessConfiguration");
            try
            {
                #if DESKTOP
                return client.PutBlockPublicAccessConfiguration(request);
                #elif CORECLR
                return client.PutBlockPublicAccessConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? BlockPublicAccessConfiguration_BlockPublicSecurityGroupRule { get; set; }
            public List<Amazon.ElasticMapReduce.Model.PortRange> BlockPublicAccessConfiguration_PermittedPublicSecurityGroupRuleRange { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.PutBlockPublicAccessConfigurationResponse, WriteEMRBlockPublicAccessConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
