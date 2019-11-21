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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Gets information about the current <a>ApiKeys</a> resource.<br/><br/>In the AWS.Tools.APIGateway module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "AGApiKeyList")]
    [OutputType("Amazon.APIGateway.Model.GetApiKeysResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway GetApiKeys API operation.", Operation = new[] {"GetApiKeys"}, SelectReturnType = typeof(Amazon.APIGateway.Model.GetApiKeysResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.GetApiKeysResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.GetApiKeysResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAGApiKeyListCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter CustomerId
        /// <summary>
        /// <para>
        /// <para>The identifier of a customer in AWS Marketplace or an external system, such as a developer
        /// portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerId { get; set; }
        #endregion
        
        #region Parameter IncludeValue
        /// <summary>
        /// <para>
        /// <para>A boolean flag to specify whether (<code>true</code>) or not (<code>false</code>)
        /// the result contains key values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeValues")]
        public System.Boolean? IncludeValue { get; set; }
        #endregion
        
        #region Parameter NameQuery
        /// <summary>
        /// <para>
        /// <para>The name of queried API keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NameQuery { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of returned results per page. The default value is 25 and the maximum
        /// value is 500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter Position
        /// <summary>
        /// <para>
        /// <para>The current pagination position in the paged result set.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.APIGateway module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-Position $null' for the first call and '-Position $AWSHistory.LastServiceResponse.Position' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Position { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.GetApiKeysResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.GetApiKeysResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Position
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.GetApiKeysResponse, GetAGApiKeyListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CustomerId = this.CustomerId;
            context.IncludeValue = this.IncludeValue;
            context.Limit = this.Limit;
            context.NameQuery = this.NameQuery;
            context.Position = this.Position;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.APIGateway.Model.GetApiKeysRequest();
            
            if (cmdletContext.CustomerId != null)
            {
                request.CustomerId = cmdletContext.CustomerId;
            }
            if (cmdletContext.IncludeValue != null)
            {
                request.IncludeValues = cmdletContext.IncludeValue.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.NameQuery != null)
            {
                request.NameQuery = cmdletContext.NameQuery;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Position;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Position));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Position = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.Position;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.APIGateway.Model.GetApiKeysRequest();
            
            if (cmdletContext.CustomerId != null)
            {
                request.CustomerId = cmdletContext.CustomerId;
            }
            if (cmdletContext.IncludeValue != null)
            {
                request.IncludeValues = cmdletContext.IncludeValue.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.NameQuery != null)
            {
                request.NameQuery = cmdletContext.NameQuery;
            }
            if (cmdletContext.Position != null)
            {
                request.Position = cmdletContext.Position;
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.APIGateway.Model.GetApiKeysResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetApiKeysRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetApiKeys");
            try
            {
                #if DESKTOP
                return client.GetApiKeys(request);
                #elif CORECLR
                return client.GetApiKeysAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomerId { get; set; }
            public System.Boolean? IncludeValue { get; set; }
            public int? Limit { get; set; }
            public System.String NameQuery { get; set; }
            public System.String Position { get; set; }
            public System.Func<Amazon.APIGateway.Model.GetApiKeysResponse, GetAGApiKeyListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
