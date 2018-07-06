/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    ///  <note><para>
    /// AWS Config should be enabled in source accounts and regions you want to aggregate.
    /// </para><para>
    /// If your source type is an organization, you must be signed in to the master account
    /// and all features must be enabled in your organization. AWS Config calls <code>EnableAwsServiceAccess</code>
    /// API to enable integration between AWS Config and AWS Organizations. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGConfigurationAggregator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.ConfigurationAggregator")]
    [AWSCmdlet("Calls the AWS Config PutConfigurationAggregator API operation.", Operation = new[] {"PutConfigurationAggregator"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConfigurationAggregator",
        "This cmdlet returns a ConfigurationAggregator object.",
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
        [System.Management.Automation.Parameter]
        [Alias("AccountAggregationSources")]
        public Amazon.ConfigService.Model.AccountAggregationSource[] AccountAggregationSource { get; set; }
        #endregion
        
        #region Parameter OrganizationAggregationSource_AllAwsRegion
        /// <summary>
        /// <para>
        /// <para>If true, aggregate existing AWS Config regions and future regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OrganizationAggregationSource_AllAwsRegions")]
        public System.Boolean OrganizationAggregationSource_AllAwsRegion { get; set; }
        #endregion
        
        #region Parameter OrganizationAggregationSource_AwsRegion
        /// <summary>
        /// <para>
        /// <para>The source regions being aggregated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OrganizationAggregationSource_AwsRegions")]
        public System.String[] OrganizationAggregationSource_AwsRegion { get; set; }
        #endregion
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter OrganizationAggregationSource_RoleArn
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role used to retreive AWS Organization details associated with the
        /// aggregator account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OrganizationAggregationSource_RoleArn { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConfigurationAggregatorName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGConfigurationAggregator (PutConfigurationAggregator)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AccountAggregationSource != null)
            {
                context.AccountAggregationSources = new List<Amazon.ConfigService.Model.AccountAggregationSource>(this.AccountAggregationSource);
            }
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            if (ParameterWasBound("OrganizationAggregationSource_AllAwsRegion"))
                context.OrganizationAggregationSource_AllAwsRegions = this.OrganizationAggregationSource_AllAwsRegion;
            if (this.OrganizationAggregationSource_AwsRegion != null)
            {
                context.OrganizationAggregationSource_AwsRegions = new List<System.String>(this.OrganizationAggregationSource_AwsRegion);
            }
            context.OrganizationAggregationSource_RoleArn = this.OrganizationAggregationSource_RoleArn;
            
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
            
            if (cmdletContext.AccountAggregationSources != null)
            {
                request.AccountAggregationSources = cmdletContext.AccountAggregationSources;
            }
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            
             // populate OrganizationAggregationSource
            bool requestOrganizationAggregationSourceIsNull = true;
            request.OrganizationAggregationSource = new Amazon.ConfigService.Model.OrganizationAggregationSource();
            System.Boolean? requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion = null;
            if (cmdletContext.OrganizationAggregationSource_AllAwsRegions != null)
            {
                requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion = cmdletContext.OrganizationAggregationSource_AllAwsRegions.Value;
            }
            if (requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion != null)
            {
                request.OrganizationAggregationSource.AllAwsRegions = requestOrganizationAggregationSource_organizationAggregationSource_AllAwsRegion.Value;
                requestOrganizationAggregationSourceIsNull = false;
            }
            List<System.String> requestOrganizationAggregationSource_organizationAggregationSource_AwsRegion = null;
            if (cmdletContext.OrganizationAggregationSource_AwsRegions != null)
            {
                requestOrganizationAggregationSource_organizationAggregationSource_AwsRegion = cmdletContext.OrganizationAggregationSource_AwsRegions;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ConfigurationAggregator;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutConfigurationAggregatorAsync(request);
                return task.Result;
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
            public List<Amazon.ConfigService.Model.AccountAggregationSource> AccountAggregationSources { get; set; }
            public System.String ConfigurationAggregatorName { get; set; }
            public System.Boolean? OrganizationAggregationSource_AllAwsRegions { get; set; }
            public List<System.String> OrganizationAggregationSource_AwsRegions { get; set; }
            public System.String OrganizationAggregationSource_RoleArn { get; set; }
        }
        
    }
}
