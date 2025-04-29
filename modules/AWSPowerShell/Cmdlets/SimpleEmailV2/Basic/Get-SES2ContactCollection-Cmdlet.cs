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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Lists the contacts present in a specific contact list.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SES2ContactCollection")]
    [OutputType("Amazon.SimpleEmailV2.Model.Contact")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) ListContacts API operation.", Operation = new[] {"ListContacts"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.ListContactsResponse))]
    [AWSCmdletOutput("Amazon.SimpleEmailV2.Model.Contact or Amazon.SimpleEmailV2.Model.ListContactsResponse",
        "This cmdlet returns a collection of Amazon.SimpleEmailV2.Model.Contact objects.",
        "The service call response (type Amazon.SimpleEmailV2.Model.ListContactsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSES2ContactCollectionCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContactListName
        /// <summary>
        /// <para>
        /// <para>The name of the contact list.</para>
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
        public System.String ContactListName { get; set; }
        #endregion
        
        #region Parameter Filter_FilteredStatus
        /// <summary>
        /// <para>
        /// <para>The status by which you are filtering: <c>OPT_IN</c> or <c>OPT_OUT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.SubscriptionStatus")]
        public Amazon.SimpleEmailV2.SubscriptionStatus Filter_FilteredStatus { get; set; }
        #endregion
        
        #region Parameter TopicFilter_TopicName
        /// <summary>
        /// <para>
        /// <para>The name of a topic on which you wish to apply the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_TopicFilter_TopicName")]
        public System.String TopicFilter_TopicName { get; set; }
        #endregion
        
        #region Parameter TopicFilter_UseDefaultIfPreferenceUnavailable
        /// <summary>
        /// <para>
        /// <para>Notes that the default subscription status should be applied to a contact because
        /// the contact has not noted their preference for subscribing to a topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_TopicFilter_UseDefaultIfPreferenceUnavailable")]
        public System.Boolean? TopicFilter_UseDefaultIfPreferenceUnavailable { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A string token indicating that there might be additional contacts available to be
        /// listed. Use the token provided in the Response to use in the subsequent call to ListContacts
        /// with the same parameters to retrieve the next page of contacts.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The number of contacts that may be returned at once, which is dependent on if there
        /// are more or less contacts than the value of the PageSize. Use this parameter to paginate
        /// results. If additional contacts exist beyond the specified limit, the <c>NextToken</c>
        /// element is sent in the response. Use the <c>NextToken</c> value in subsequent requests
        /// to retrieve additional contacts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Contacts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.ListContactsResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmailV2.Model.ListContactsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Contacts";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.ListContactsResponse, GetSES2ContactCollectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContactListName = this.ContactListName;
            #if MODULAR
            if (this.ContactListName == null && ParameterWasBound(nameof(this.ContactListName)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactListName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Filter_FilteredStatus = this.Filter_FilteredStatus;
            context.TopicFilter_TopicName = this.TopicFilter_TopicName;
            context.TopicFilter_UseDefaultIfPreferenceUnavailable = this.TopicFilter_UseDefaultIfPreferenceUnavailable;
            context.NextToken = this.NextToken;
            context.PageSize = this.PageSize;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SimpleEmailV2.Model.ListContactsRequest();
            
            if (cmdletContext.ContactListName != null)
            {
                request.ContactListName = cmdletContext.ContactListName;
            }
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.SimpleEmailV2.Model.ListContactsFilter();
            Amazon.SimpleEmailV2.SubscriptionStatus requestFilter_filter_FilteredStatus = null;
            if (cmdletContext.Filter_FilteredStatus != null)
            {
                requestFilter_filter_FilteredStatus = cmdletContext.Filter_FilteredStatus;
            }
            if (requestFilter_filter_FilteredStatus != null)
            {
                request.Filter.FilteredStatus = requestFilter_filter_FilteredStatus;
                requestFilterIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.TopicFilter requestFilter_filter_TopicFilter = null;
            
             // populate TopicFilter
            var requestFilter_filter_TopicFilterIsNull = true;
            requestFilter_filter_TopicFilter = new Amazon.SimpleEmailV2.Model.TopicFilter();
            System.String requestFilter_filter_TopicFilter_topicFilter_TopicName = null;
            if (cmdletContext.TopicFilter_TopicName != null)
            {
                requestFilter_filter_TopicFilter_topicFilter_TopicName = cmdletContext.TopicFilter_TopicName;
            }
            if (requestFilter_filter_TopicFilter_topicFilter_TopicName != null)
            {
                requestFilter_filter_TopicFilter.TopicName = requestFilter_filter_TopicFilter_topicFilter_TopicName;
                requestFilter_filter_TopicFilterIsNull = false;
            }
            System.Boolean? requestFilter_filter_TopicFilter_topicFilter_UseDefaultIfPreferenceUnavailable = null;
            if (cmdletContext.TopicFilter_UseDefaultIfPreferenceUnavailable != null)
            {
                requestFilter_filter_TopicFilter_topicFilter_UseDefaultIfPreferenceUnavailable = cmdletContext.TopicFilter_UseDefaultIfPreferenceUnavailable.Value;
            }
            if (requestFilter_filter_TopicFilter_topicFilter_UseDefaultIfPreferenceUnavailable != null)
            {
                requestFilter_filter_TopicFilter.UseDefaultIfPreferenceUnavailable = requestFilter_filter_TopicFilter_topicFilter_UseDefaultIfPreferenceUnavailable.Value;
                requestFilter_filter_TopicFilterIsNull = false;
            }
             // determine if requestFilter_filter_TopicFilter should be set to null
            if (requestFilter_filter_TopicFilterIsNull)
            {
                requestFilter_filter_TopicFilter = null;
            }
            if (requestFilter_filter_TopicFilter != null)
            {
                request.Filter.TopicFilter = requestFilter_filter_TopicFilter;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
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
                    
                    _nextToken = response.NextToken;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleEmailV2.Model.ListContactsResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.ListContactsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "ListContacts");
            try
            {
                return client.ListContactsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContactListName { get; set; }
            public Amazon.SimpleEmailV2.SubscriptionStatus Filter_FilteredStatus { get; set; }
            public System.String TopicFilter_TopicName { get; set; }
            public System.Boolean? TopicFilter_UseDefaultIfPreferenceUnavailable { get; set; }
            public System.String NextToken { get; set; }
            public System.Int32? PageSize { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.ListContactsResponse, GetSES2ContactCollectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Contacts;
        }
        
    }
}
