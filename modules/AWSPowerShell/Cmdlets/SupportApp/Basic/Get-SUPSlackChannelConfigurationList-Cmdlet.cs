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
using Amazon.SupportApp;
using Amazon.SupportApp.Model;

namespace Amazon.PowerShell.Cmdlets.SUP
{
    /// <summary>
    /// Lists the Slack channel configurations for an Amazon Web Services account.
    /// </summary>
    [Cmdlet("Get", "SUPSlackChannelConfigurationList")]
    [OutputType("Amazon.SupportApp.Model.SlackChannelConfiguration")]
    [AWSCmdlet("Calls the AWS Support App ListSlackChannelConfigurations API operation.", Operation = new[] {"ListSlackChannelConfigurations"}, SelectReturnType = typeof(Amazon.SupportApp.Model.ListSlackChannelConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.SupportApp.Model.SlackChannelConfiguration or Amazon.SupportApp.Model.ListSlackChannelConfigurationsResponse",
        "This cmdlet returns a collection of Amazon.SupportApp.Model.SlackChannelConfiguration objects.",
        "The service call response (type Amazon.SupportApp.Model.ListSlackChannelConfigurationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSUPSlackChannelConfigurationListCmdlet : AmazonSupportAppClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the results of a search are large, the API only returns a portion of the results
        /// and includes a <c>nextToken</c> pagination token in the response. To retrieve the
        /// next batch of results, reissue the search request and include the returned token.
        /// When the API returns the last set of results, the response doesn't include a pagination
        /// token value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SlackChannelConfigurations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupportApp.Model.ListSlackChannelConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.SupportApp.Model.ListSlackChannelConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SlackChannelConfigurations";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupportApp.Model.ListSlackChannelConfigurationsResponse, GetSUPSlackChannelConfigurationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.SupportApp.Model.ListSlackChannelConfigurationsRequest();
            
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.SupportApp.Model.ListSlackChannelConfigurationsResponse CallAWSServiceOperation(IAmazonSupportApp client, Amazon.SupportApp.Model.ListSlackChannelConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support App", "ListSlackChannelConfigurations");
            try
            {
                #if DESKTOP
                return client.ListSlackChannelConfigurations(request);
                #elif CORECLR
                return client.ListSlackChannelConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SupportApp.Model.ListSlackChannelConfigurationsResponse, GetSUPSlackChannelConfigurationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SlackChannelConfigurations;
        }
        
    }
}
