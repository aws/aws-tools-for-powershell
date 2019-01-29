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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// An auto-complete API for the search functionality in the Amazon SageMaker console.
    /// It returns suggestions of possible matches for the property name to use in <code>Search</code>
    /// queries. Provides suggestions for <code>HyperParameters</code>, <code>Tags</code>,
    /// and <code>Metrics</code>.
    /// </summary>
    [Cmdlet("Get", "SMSearchSuggestion")]
    [OutputType("Amazon.SageMaker.Model.PropertyNameSuggestion")]
    [AWSCmdlet("Calls the Amazon SageMaker Service GetSearchSuggestions API operation.", Operation = new[] {"GetSearchSuggestions"})]
    [AWSCmdletOutput("Amazon.SageMaker.Model.PropertyNameSuggestion",
        "This cmdlet returns a collection of PropertyNameSuggestion objects.",
        "The service call response (type Amazon.SageMaker.Model.GetSearchSuggestionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSMSearchSuggestionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter PropertyNameQuery_PropertyNameHint
        /// <summary>
        /// <para>
        /// <para>Text that is part of a property's name. The property names of hyperparameter, metric,
        /// and tag key names that begin with the specified text in the <code>PropertyNameHint</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SuggestionQuery_PropertyNameQuery_PropertyNameHint")]
        public System.String PropertyNameQuery_PropertyNameHint { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon SageMaker resource to Search for. The only valid <code>Resource</code>
        /// value is <code>TrainingJob</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ResourceType")]
        public Amazon.SageMaker.ResourceType Resource { get; set; }
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
            
            context.Resource = this.Resource;
            context.SuggestionQuery_PropertyNameQuery_PropertyNameHint = this.PropertyNameQuery_PropertyNameHint;
            
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
            bool requestSuggestionQueryIsNull = true;
            request.SuggestionQuery = new Amazon.SageMaker.Model.SuggestionQuery();
            Amazon.SageMaker.Model.PropertyNameQuery requestSuggestionQuery_suggestionQuery_PropertyNameQuery = null;
            
             // populate PropertyNameQuery
            bool requestSuggestionQuery_suggestionQuery_PropertyNameQueryIsNull = true;
            requestSuggestionQuery_suggestionQuery_PropertyNameQuery = new Amazon.SageMaker.Model.PropertyNameQuery();
            System.String requestSuggestionQuery_suggestionQuery_PropertyNameQuery_propertyNameQuery_PropertyNameHint = null;
            if (cmdletContext.SuggestionQuery_PropertyNameQuery_PropertyNameHint != null)
            {
                requestSuggestionQuery_suggestionQuery_PropertyNameQuery_propertyNameQuery_PropertyNameHint = cmdletContext.SuggestionQuery_PropertyNameQuery_PropertyNameHint;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PropertyNameSuggestions;
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
        
        private Amazon.SageMaker.Model.GetSearchSuggestionsResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.GetSearchSuggestionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "GetSearchSuggestions");
            try
            {
                #if DESKTOP
                return client.GetSearchSuggestions(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetSearchSuggestionsAsync(request);
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
            public Amazon.SageMaker.ResourceType Resource { get; set; }
            public System.String SuggestionQuery_PropertyNameQuery_PropertyNameHint { get; set; }
        }
        
    }
}
