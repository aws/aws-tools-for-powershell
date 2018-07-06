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
    /// Returns the details of one or more retention configurations. If the retention configuration
    /// name is not specified, this action returns the details for all the retention configurations
    /// for that account.
    /// 
    ///  <note><para>
    /// Currently, AWS Config supports only one retention configuration per region in your
    /// account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGRetentionConfiguration")]
    [OutputType("Amazon.ConfigService.Model.RetentionConfiguration")]
    [AWSCmdlet("Calls the AWS Config DescribeRetentionConfigurations API operation.", Operation = new[] {"DescribeRetentionConfigurations"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.RetentionConfiguration",
        "This cmdlet returns a collection of RetentionConfiguration objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeRetentionConfigurationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCFGRetentionConfigurationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter RetentionConfigurationName
        /// <summary>
        /// <para>
        /// <para>A list of names of retention configurations for which you want details. If you do
        /// not specify a name, AWS Config returns details for all the retention configurations
        /// for that account.</para><note><para>Currently, AWS Config supports only one retention configuration per region in your
        /// account.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RetentionConfigurationNames")]
        public System.String[] RetentionConfigurationName { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.NextToken = this.NextToken;
            if (this.RetentionConfigurationName != null)
            {
                context.RetentionConfigurationNames = new List<System.String>(this.RetentionConfigurationName);
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
            var request = new Amazon.ConfigService.Model.DescribeRetentionConfigurationsRequest();
            
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.RetentionConfigurationNames != null)
            {
                request.RetentionConfigurationNames = cmdletContext.RetentionConfigurationNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RetentionConfigurations;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
        
        private Amazon.ConfigService.Model.DescribeRetentionConfigurationsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DescribeRetentionConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DescribeRetentionConfigurations");
            try
            {
                #if DESKTOP
                return client.DescribeRetentionConfigurations(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeRetentionConfigurationsAsync(request);
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
            public System.String NextToken { get; set; }
            public List<System.String> RetentionConfigurationNames { get; set; }
        }
        
    }
}
