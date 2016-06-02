/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Retrieves a list of the ACM Certificate ARNs, and the domain name for each ARN, owned
    /// by the calling account. You can filter the list based on the <code>CertificateStatuses</code>
    /// parameter, and you can display up to <code>MaxItems</code> certificates at one time.
    /// If you have more than <code>MaxItems</code> certificates, use the <code>NextToken</code>
    /// marker from the response object in your next call to the <code>ListCertificates</code>
    /// action to retrieve the next set of certificate ARNs.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "ACMCertificateList")]
    [OutputType("Amazon.CertificateManager.Model.CertificateSummary")]
    [AWSCmdlet("Invokes the ListCertificates operation against AWS Certificate Manager.", Operation = new[] {"ListCertificates"})]
    [AWSCmdletOutput("Amazon.CertificateManager.Model.CertificateSummary",
        "This cmdlet returns a collection of CertificateSummary objects.",
        "The service call response (type Amazon.CertificateManager.Model.ListCertificatesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetACMCertificateListCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateStatus
        /// <summary>
        /// <para>
        /// <para> Identifies the statuses of the ACM Certificates for which you want to retrieve the
        /// ARNs. This can be one or more of the following values: <ul><li><para><code>PENDING_VALIDATION</code></para></li><li><para><code>ISSUED</code></para></li><li><para><code>INACTIVE</code></para></li><li><para><code>EXPIRED</code></para></li><li><para><code>VALIDATION_TIMED_OUT</code></para></li><li><para><code>REVOKED</code></para></li><li><para><code>FAILED</code></para></li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("CertificateStatuses")]
        public System.String[] CertificateStatus { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para> Specify this parameter when paginating results to indicate the maximum number of
        /// ACM Certificates that you want to display for each response. If there are additional
        /// certificates beyond the maximum you specify, use the <code>NextToken</code> value
        /// in your next call to the <code>ListCertificates</code> action. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> String that contains an opaque marker of the next ACM Certificate ARN to be displayed.
        /// Use this parameter when paginating results, and only in a subsequent request after
        /// you've received a response where the results have been truncated. Set it to an empty
        /// string the first time you call this action, and set it to the value of the <code>NextToken</code>
        /// element you receive in the response object for subsequent calls. </para>
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
            
            if (this.CertificateStatus != null)
            {
                context.CertificateStatuses = new List<System.String>(this.CertificateStatus);
            }
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            context.NextToken = this.NextToken;
            
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
                _emitLimit = cmdletContext.MaxItems;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxItems);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
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
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private static Amazon.CertificateManager.Model.ListCertificatesResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.ListCertificatesRequest request)
        {
            return client.ListCertificates(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> CertificateStatuses { get; set; }
            public int? MaxItems { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
