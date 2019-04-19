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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Retrieves a list of certificate ARNs and domain names. You can request that only certificates
    /// that match a specific status be listed. You can also filter by specific attributes
    /// of the certificate.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "ACMCertificateList")]
    [OutputType("Amazon.CertificateManager.Model.CertificateSummary")]
    [AWSCmdlet("Calls the AWS Certificate Manager ListCertificates API operation.", Operation = new[] {"ListCertificates"})]
    [AWSCmdletOutput("Amazon.CertificateManager.Model.CertificateSummary",
        "This cmdlet returns a collection of CertificateSummary objects.",
        "The service call response (type Amazon.CertificateManager.Model.ListCertificatesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetACMCertificateListCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateStatus
        /// <summary>
        /// <para>
        /// <para>Filter the certificate list by status value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CertificateStatuses")]
        public System.String[] CertificateStatus { get; set; }
        #endregion
        
        #region Parameter Includes_ExtendedKeyUsage
        /// <summary>
        /// <para>
        /// <para>Specify one or more <a>ExtendedKeyUsage</a> extension values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] Includes_ExtendedKeyUsage { get; set; }
        #endregion
        
        #region Parameter Includes_KeyType
        /// <summary>
        /// <para>
        /// <para>Specify one or more algorithms that can be used to generate key pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Includes_KeyTypes")]
        public System.String[] Includes_KeyType { get; set; }
        #endregion
        
        #region Parameter Includes_KeyUsage
        /// <summary>
        /// <para>
        /// <para>Specify one or more <a>KeyUsage</a> extension values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] Includes_KeyUsage { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Use this parameter when paginating results to specify the maximum number of items
        /// to return in the response. If additional items exist beyond the number you specify,
        /// the <code>NextToken</code> element is sent in the response. Use this <code>NextToken</code>
        /// value in a subsequent request to retrieve additional items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Use this parameter only when paginating results and only in a subsequent request after
        /// you receive a response with truncated results. Set it to the value of <code>NextToken</code>
        /// from the response you just received.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
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
            
            if (this.CertificateStatus != null)
            {
                context.CertificateStatuses = new List<System.String>(this.CertificateStatus);
            }
            if (this.Includes_ExtendedKeyUsage != null)
            {
                context.Includes_ExtendedKeyUsage = new List<System.String>(this.Includes_ExtendedKeyUsage);
            }
            if (this.Includes_KeyType != null)
            {
                context.Includes_KeyTypes = new List<System.String>(this.Includes_KeyType);
            }
            if (this.Includes_KeyUsage != null)
            {
                context.Includes_KeyUsage = new List<System.String>(this.Includes_KeyUsage);
            }
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
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
            
            // create request and set iteration invariants
            var request = new Amazon.CertificateManager.Model.ListCertificatesRequest();
            if (cmdletContext.CertificateStatuses != null)
            {
                request.CertificateStatuses = cmdletContext.CertificateStatuses;
            }
            
             // populate Includes
            bool requestIncludesIsNull = true;
            request.Includes = new Amazon.CertificateManager.Model.Filters();
            List<System.String> requestIncludes_includes_ExtendedKeyUsage = null;
            if (cmdletContext.Includes_ExtendedKeyUsage != null)
            {
                requestIncludes_includes_ExtendedKeyUsage = cmdletContext.Includes_ExtendedKeyUsage;
            }
            if (requestIncludes_includes_ExtendedKeyUsage != null)
            {
                request.Includes.ExtendedKeyUsage = requestIncludes_includes_ExtendedKeyUsage;
                requestIncludesIsNull = false;
            }
            List<System.String> requestIncludes_includes_KeyType = null;
            if (cmdletContext.Includes_KeyTypes != null)
            {
                requestIncludes_includes_KeyType = cmdletContext.Includes_KeyTypes;
            }
            if (requestIncludes_includes_KeyType != null)
            {
                request.Includes.KeyTypes = requestIncludes_includes_KeyType;
                requestIncludesIsNull = false;
            }
            List<System.String> requestIncludes_includes_KeyUsage = null;
            if (cmdletContext.Includes_KeyUsage != null)
            {
                requestIncludes_includes_KeyUsage = cmdletContext.Includes_KeyUsage;
            }
            if (requestIncludes_includes_KeyUsage != null)
            {
                request.Includes.KeyUsage = requestIncludes_includes_KeyUsage;
                requestIncludesIsNull = false;
            }
             // determine if request.Includes should be set to null
            if (requestIncludesIsNull)
            {
                request.Includes = null;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxItems))
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxItems;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken");
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    int correctPageSize = 1000;
                    if (_emitLimit.HasValue)
                    {
                        correctPageSize = AutoIterationHelpers.Min(1000, _emitLimit.Value);
                    }
                    request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.CertificateSummaryList;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.CertificateSummaryList.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        _retrievedSoFar += _receivedThisCall;
                        if (_emitLimit.HasValue)
                        {
                            _emitLimit -= _receivedThisCall;
                        }
                    }
                    catch (Exception e)
                    {
                        if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                        {
                            output = new CmdletOutput { ErrorResponse = e };
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    ProcessOutput(output);
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
            }
            finally
            {
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CertificateManager.Model.ListCertificatesResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.ListCertificatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "ListCertificates");
            try
            {
                #if DESKTOP
                return client.ListCertificates(request);
                #elif CORECLR
                return client.ListCertificatesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CertificateStatuses { get; set; }
            public List<System.String> Includes_ExtendedKeyUsage { get; set; }
            public List<System.String> Includes_KeyTypes { get; set; }
            public List<System.String> Includes_KeyUsage { get; set; }
            public int? MaxItems { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
