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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// An auto-complete API for the search functionality in the SageMaker console. It returns
    /// suggestions of possible matches for the property name to use in <c>Search</c> queries.
    /// Provides suggestions for <c>HyperParameters</c>, <c>Tags</c>, and <c>Metrics</c>.
    /// </summary>
    [Cmdlet("Get", "SMSearchSuggestion")]
    [OutputType("Amazon.SageMaker.Model.PropertyNameSuggestion")]
    [AWSCmdlet("Calls the Amazon SageMaker Service GetSearchSuggestions API operation.", Operation = new[] {"GetSearchSuggestions"}, SelectReturnType = typeof(Amazon.SageMaker.Model.GetSearchSuggestionsResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.PropertyNameSuggestion or Amazon.SageMaker.Model.GetSearchSuggestionsResponse",
        "This cmdlet returns a collection of Amazon.SageMaker.Model.PropertyNameSuggestion objects.",
        "The service call response (type Amazon.SageMaker.Model.GetSearchSuggestionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSMSearchSuggestionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PropertyNameQuery_PropertyNameHint
        /// <summary>
        /// <para>
        /// <para>Text that begins a property's name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SuggestionQuery_PropertyNameQuery_PropertyNameHint")]
        public System.String PropertyNameQuery_PropertyNameHint { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The name of the SageMaker resource to search for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.ResourceType")]
        public Amazon.SageMaker.ResourceType Resource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PropertyNameSuggestions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.GetSearchSuggestionsResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.GetSearchSuggestionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PropertyNameSuggestions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Resource parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Resource' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Resource' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.GetSearchSuggestionsResponse, GetSMSearchSuggestionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Resource;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Resource = this.Resource;
            #if MODULAR
            if (this.Resource == null && ParameterWasBound(nameof(this.Resource)))
            {
                WriteWarning("You are passing $null as a value for parameter Resource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PropertyNameQuery_PropertyNameHint = this.PropertyNameQuery_PropertyNameHint;
            
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
            var request = new Amazon.SageMaker.Model.GetSearchSuggestionsRequest();
            
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            
             // populate SuggestionQuery
            var requestSuggestionQueryIsNull = true;
            request.SuggestionQuery = new Amazon.SageMaker.Model.SuggestionQuery();
            Amazon.SageMaker.Model.PropertyNameQuery requestSuggestionQuery_suggestionQuery_PropertyNameQuery = null;
            
             // populate PropertyNameQuery
            var requestSuggestionQuery_suggestionQuery_PropertyNameQueryIsNull = true;
            requestSuggestionQuery_suggestionQuery_PropertyNameQuery = new Amazon.SageMaker.Model.PropertyNameQuery();
            System.String requestSuggestionQuery_suggestionQuery_PropertyNameQuery_propertyNameQuery_PropertyNameHint = null;
            if (cmdletContext.PropertyNameQuery_PropertyNameHint != null)
            {
                requestSuggestionQuery_suggestionQuery_PropertyNameQuery_propertyNameQuery_PropertyNameHint = cmdletContext.PropertyNameQuery_PropertyNameHint;
            }
            if (requestSuggestionQuery_suggestionQuery_PropertyNameQuery_propertyNameQuery_PropertyNameHint != null)
            {
                requestSuggestionQuery_suggestionQuery_PropertyNameQuery.PropertyNameHint = requestSuggestionQuery_suggestionQuery_PropertyNameQuery_propertyNameQuery_PropertyNameHint;
                requestSuggestionQuery_suggestionQuery_PropertyNameQueryIsNull = false;
            }
             // determine if requestSuggestionQuery_suggestionQuery_PropertyNameQuery should be set to null
            if (requestSuggestionQuery_suggestionQuery_PropertyNameQueryIsNull)
            {
                requestSuggestionQuery_suggestionQuery_PropertyNameQuery = null;
            }
            if (requestSuggestionQuery_suggestionQuery_PropertyNameQuery != null)
            {
                request.SuggestionQuery.PropertyNameQuery = requestSuggestionQuery_suggestionQuery_PropertyNameQuery;
                requestSuggestionQueryIsNull = false;
            }
             // determine if request.SuggestionQuery should be set to null
            if (requestSuggestionQueryIsNull)
            {
                request.SuggestionQuery = null;
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
        
        private Amazon.SageMaker.Model.GetSearchSuggestionsResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.GetSearchSuggestionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "GetSearchSuggestions");
            try
            {
                #if DESKTOP
                return client.GetSearchSuggestions(request);
                #elif CORECLR
                return client.GetSearchSuggestionsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.ResourceType Resource { get; set; }
            public System.String PropertyNameQuery_PropertyNameHint { get; set; }
            public System.Func<Amazon.SageMaker.Model.GetSearchSuggestionsResponse, GetSMSearchSuggestionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PropertyNameSuggestions;
        }
        
    }
}
