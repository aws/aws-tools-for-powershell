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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates and updates the configuration aggregator with the selected source accounts
    /// and regions. The source account can be individual account(s) or an organization.
    /// 
    ///  
    /// <para><code>accountIds</code> that are passed will be replaced with existing accounts.
    /// If you want to add additional accounts into the aggregator, call <code>DescribeAggregator</code>
    /// to get the previous accounts and then append new ones.
    /// </para><note><para>
    /// AWS Config should be enabled in source accounts and regions you want to aggregate.
    /// </para><para>
    /// If your source type is an organization, you must be signed in to the management account
    /// or a registered delegated administrator and all the features must be enabled in your
    /// organization. If the caller is a management account, AWS Config calls <code>EnableAwsServiceAccess</code>
    /// API to enable integration between AWS Config and AWS Organizations. If the caller
    /// is a registered delegated administrator, AWS Config calls <code>ListDelegatedAdministrators</code>
    /// API to verify whether the caller is a valid delegated administrator.
    /// </para><para>
    /// To register a delegated administrator, see <a href="https://docs.aws.amazon.com/config/latest/developerguide/set-up-aggregator-cli.html#register-a-delegated-administrator-cli">Register
    /// a Delegated Administrator</a> in the AWS Config developer guide. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGConfigurationAggregator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.ConfigurationAggregator")]
    [AWSCmdlet("Calls the AWS Config PutConfigurationAggregator API operation.", Operation = new[] {"PutConfigurationAggregator"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutConfigurationAggregatorResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigurationAggregator or Amazon.ConfigService.Model.PutConfigurationAggregatorResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.ConfigurationAggregator object.",
        "The service call response (type Amazon.ConfigService.Model.PutConfigurationAggregatorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGConfigurationAggregatorCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AccountAggregationSource
        /// <summary>
        /// <para>
        /// <para>A list of AccountAggregationSource object. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountAggregationSources")]
        public Amazon.ConfigService.Model.AccountAggregationSource[] AccountAggregationSource { get; set; }
        #endregion
        
        #region Parameter OrganizationAggregationSource_AllAwsRegion
        /// <summary>
        /// <para>
        /// <para>If true, aggregate existing AWS Config regions and future regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationAggregationSource_AllAwsRegions")]
        public System.Boolean? OrganizationAggregationSource_AllAwsRegion { get; set; }
        #endregion
        
        #region Parameter OrganizationAggregationSource_AwsRegion
        /// <summary>
        /// <para>
        /// <para>The source regions being aggregated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationAggregationSource_AwsRegions")]
        public System.String[] OrganizationAggregationSource_AwsRegion { get; set; }
        #endregion
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
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
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter OrganizationAggregationSource_RoleArn
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role used to retrieve AWS Organization details associated with the
        /// aggregator account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationAggregationSource_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of tag object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ConfigService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfigurationAggregator'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutConfigurationAggregatorResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutConfigurationAggregatorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfigurationAggregator";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigurationAggregatorName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigurationAggregatorName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigurationAggregatorName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationAggregatorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGConfigurationAggregator (PutConfigurationAggregator)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutConfigurationAggregatorResponse, WriteCFGConfigurationAggregatorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigurationAggregatorName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccountAggregationSource != null)
            {
                context.AccountAggregationSource = new List<Amazon.ConfigService.Model.AccountAggregationSource>(this.AccountAggregationSource);
            }
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            #if MODULAR
            if (this.ConfigurationAggregatorName == null && ParameterWasBound(nameof(this.ConfigurationAggregatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationAggregatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationAggregationSource_AllAwsRegion = this.OrganizationAggregationSource_AllAwsRegion;
            if (this.OrganizationAggregationSource_AwsRegion != null)
            {
                context.OrganizationAggregationSource_AwsRegion = new List<System.String>(this.OrganizationAggregationSource_AwsRegion);
            }
            context.OrganizationAggregationSource_RoleArn = this.OrganizationAggregationSource_RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ConfigService.Model.Tag>(this.Tag);
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
            var request = new Amazon.ConfigService.Model.PutConfigurationAggregatorRequest();
            
            if (cmdletContext.AccountAggregationSource != null)
            {
                request.AccountAggregationSources = cmdletContext.AccountAggregationSource;
            }
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            
             // populate OrganizationAggregationSource
            var requestOrganizationAggregationSourceIsNull = true;
            request.OrganizationAggregationSource = new Amazon.ConfigService.Model.OrganizationAggregationSource();
            System.Boolean? requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion = null;
            if (cmdletContext.OrganizationAggregationSource_AllAwsRegion != null)
            {
                requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion = cmdletContext.OrganizationAggregationSource_AllAwsRegion.Value;
            }
            if (requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion != null)
            {
                request.OrganizationAggregationSource.AllAwsRegions = requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion.Value;
                requestOrganizationAggregationSourceIsNull = false;
            }
            List<System.String> requestOrganizationAggregationSource_organizationAggregationSource_AwsRegion = null;
            if (cmdletContext.OrganizationAggregationSource_AwsRegion != null)
            {
                requestOrganizationAggregationSource_organizationAggregationSource_AwsRegion = cmdletContext.OrganizationAggregationSource_AwsRegion;
            }
            if (requestOrganizationAggregationSource_organizationAggregationSource_AwsRegion != null)
            {
                request.OrganizationAggregationSource.AwsRegions = requestOrganizationAggregationSource_organizationAggregationSource_AwsRegion;
                requestOrganizationAggregationSourceIsNull = false;
            }
            System.String requestOrganizationAggregationSource_organizationAggregationSource_RoleArn = null;
            if (cmdletContext.OrganizationAggregationSource_RoleArn != null)
            {
                requestOrganizationAggregationSource_organizationAggregationSource_RoleArn = cmdletContext.OrganizationAggregationSource_RoleArn;
            }
            if (requestOrganizationAggregationSource_organizationAggregationSource_RoleArn != null)
            {
                request.OrganizationAggregationSource.RoleArn = requestOrganizationAggregationSource_organizationAggregationSource_RoleArn;
                requestOrganizationAggregationSourceIsNull = false;
            }
             // determine if request.OrganizationAggregationSource should be set to null
            if (requestOrganizationAggregationSourceIsNull)
            {
                request.OrganizationAggregationSource = null;
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
        
        private Amazon.ConfigService.Model.PutConfigurationAggregatorResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutConfigurationAggregatorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutConfigurationAggregator");
            try
            {
                #if DESKTOP
                return client.PutConfigurationAggregator(request);
                #elif CORECLR
                return client.PutConfigurationAggregatorAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ConfigService.Model.AccountAggregationSource> AccountAggregationSource { get; set; }
            public System.String ConfigurationAggregatorName { get; set; }
            public System.Boolean? OrganizationAggregationSource_AllAwsRegion { get; set; }
            public List<System.String> OrganizationAggregationSource_AwsRegion { get; set; }
            public System.String OrganizationAggregationSource_RoleArn { get; set; }
            public List<Amazon.ConfigService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutConfigurationAggregatorResponse, WriteCFGConfigurationAggregatorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfigurationAggregator;
        }
        
    }
}
