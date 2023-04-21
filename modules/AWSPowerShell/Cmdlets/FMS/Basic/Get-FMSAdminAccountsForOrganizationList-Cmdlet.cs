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
using Amazon.FMS;
using Amazon.FMS.Model;

namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Returns a <code>AdminAccounts</code> object that lists the Firewall Manager administrators
    /// within the organization that are onboarded to Firewall Manager by <a>AssociateAdminAccount</a>.
    /// 
    ///  
    /// <para>
    /// This operation can be called only from the organization's management account.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "FMSAdminAccountsForOrganizationList")]
    [OutputType("Amazon.FMS.Model.AdminAccountSummary")]
    [AWSCmdlet("Calls the Firewall Management Service ListAdminAccountsForOrganization API operation.", Operation = new[] {"ListAdminAccountsForOrganization"}, SelectReturnType = typeof(Amazon.FMS.Model.ListAdminAccountsForOrganizationResponse))]
    [AWSCmdletOutput("Amazon.FMS.Model.AdminAccountSummary or Amazon.FMS.Model.ListAdminAccountsForOrganizationResponse",
        "This cmdlet returns a collection of Amazon.FMS.Model.AdminAccountSummary objects.",
        "The service call response (type Amazon.FMS.Model.ListAdminAccountsForOrganizationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetFMSAdminAccountsForOrganizationListCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of objects that you want Firewall Manager to return for this request.
        /// If more objects are available, in the response, Firewall Manager provides a <code>NextToken</code>
        /// value that you can use in a subsequent call to get the next batch of objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>When you request a list of objects with a <code>MaxResults</code> setting, if the
        /// number of objects that are still available for retrieval exceeds the maximum you requested,
        /// Firewall Manager returns a <code>NextToken</code> value in the response. To retrieve
        /// the next batch of objects, use the token returned from the prior request in your next
        /// request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AdminAccounts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FMS.Model.ListAdminAccountsForOrganizationResponse).
        /// Specifying the name of a property of type Amazon.FMS.Model.ListAdminAccountsForOrganizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AdminAccounts";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FMS.Model.ListAdminAccountsForOrganizationResponse, GetFMSAdminAccountsForOrganizationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.FMS.Model.ListAdminAccountsForOrganizationRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.FMS.Model.ListAdminAccountsForOrganizationResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.ListAdminAccountsForOrganizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "ListAdminAccountsForOrganization");
            try
            {
                #if DESKTOP
                return client.ListAdminAccountsForOrganization(request);
                #elif CORECLR
                return client.ListAdminAccountsForOrganizationAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.FMS.Model.ListAdminAccountsForOrganizationResponse, GetFMSAdminAccountsForOrganizationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AdminAccounts;
        }
        
    }
}
