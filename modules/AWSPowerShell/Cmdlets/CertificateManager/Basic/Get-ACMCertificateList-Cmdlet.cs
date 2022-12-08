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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Retrieves a list of certificate ARNs and domain names. You can request that only certificates
    /// that match a specific status be listed. You can also filter by specific attributes
    /// of the certificate. Default filtering returns only <code>RSA_2048</code> certificates.
    /// For more information, see <a>Filters</a>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ACMCertificateList")]
    [OutputType("Amazon.CertificateManager.Model.CertificateSummary")]
    [AWSCmdlet("Calls the AWS Certificate Manager ListCertificates API operation.", Operation = new[] {"ListCertificates"}, SelectReturnType = typeof(Amazon.CertificateManager.Model.ListCertificatesResponse))]
    [AWSCmdletOutput("Amazon.CertificateManager.Model.CertificateSummary or Amazon.CertificateManager.Model.ListCertificatesResponse",
        "This cmdlet returns a collection of Amazon.CertificateManager.Model.CertificateSummary objects.",
        "The service call response (type Amazon.CertificateManager.Model.ListCertificatesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetACMCertificateListCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateStatus
        /// <summary>
        /// <para>
        /// <para>Filter the certificate list by status value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CertificateStatuses")]
        public System.String[] CertificateStatus { get; set; }
        #endregion
        
        #region Parameter Includes_ExtendedKeyUsage
        /// <summary>
        /// <para>
        /// <para>Specify one or more <a>ExtendedKeyUsage</a> extension values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Includes_ExtendedKeyUsage { get; set; }
        #endregion
        
        #region Parameter Includes_KeyType
        /// <summary>
        /// <para>
        /// <para>Specify one or more algorithms that can be used to generate key pairs.</para><para>Default filtering returns only <code>RSA_1024</code> and <code>RSA_2048</code> certificates
        /// that have at least one domain. To return other certificate types, provide the desired
        /// type signatures in a comma-separated list. For example, <code>"keyTypes": ["RSA_2048","RSA_4096"]</code>
        /// returns both <code>RSA_2048</code> and <code>RSA_4096</code> certificates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Includes_KeyTypes")]
        public System.String[] Includes_KeyType { get; set; }
        #endregion
        
        #region Parameter Includes_KeyUsage
        /// <summary>
        /// <para>
        /// <para>Specify one or more <a>KeyUsage</a> extension values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Includes_KeyUsage { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Specifies the field to sort results by. If you specify <code>SortBy</code>, you must
        /// also specify <code>SortOrder</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CertificateManager.SortBy")]
        public Amazon.CertificateManager.SortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Specifies the order of sorted results. If you specify <code>SortOrder</code>, you
        /// must also specify <code>SortBy</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CertificateManager.SortOrder")]
        public Amazon.CertificateManager.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Use this parameter when paginating results to specify the maximum number of items
        /// to return in the response. If additional items exist beyond the number you specify,
        /// the <code>NextToken</code> element is sent in the response. Use this <code>NextToken</code>
        /// value in a subsequent request to retrieve additional items.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? MaxItem { get; set; }
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
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CertificateSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CertificateManager.Model.ListCertificatesResponse).
        /// Specifying the name of a property of type Amazon.CertificateManager.Model.ListCertificatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CertificateSummaryList";
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
                context.Select = CreateSelectDelegate<Amazon.CertificateManager.Model.ListCertificatesResponse, GetACMCertificateListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CertificateStatus != null)
            {
                context.CertificateStatus = new List<System.String>(this.CertificateStatus);
            }
            if (this.Includes_ExtendedKeyUsage != null)
            {
                context.Includes_ExtendedKeyUsage = new List<System.String>(this.Includes_ExtendedKeyUsage);
            }
            if (this.Includes_KeyType != null)
            {
                context.Includes_KeyType = new List<System.String>(this.Includes_KeyType);
            }
            if (this.Includes_KeyUsage != null)
            {
                context.Includes_KeyUsage = new List<System.String>(this.Includes_KeyUsage);
            }
            context.MaxItem = this.MaxItem;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxItem)) && this.MaxItem.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxItem parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxItem" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
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
            var request = new Amazon.CertificateManager.Model.ListCertificatesRequest();
            
            if (cmdletContext.CertificateStatus != null)
            {
                request.CertificateStatuses = cmdletContext.CertificateStatus;
            }
            
             // populate Includes
            var requestIncludesIsNull = true;
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
            if (cmdletContext.Includes_KeyType != null)
            {
                requestIncludes_includes_KeyType = cmdletContext.Includes_KeyType;
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
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxItem.Value);
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.CertificateManager.Model.ListCertificatesRequest();
            if (cmdletContext.CertificateStatus != null)
            {
                request.CertificateStatuses = cmdletContext.CertificateStatus;
            }
            
             // populate Includes
            var requestIncludesIsNull = true;
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
            if (cmdletContext.Includes_KeyType != null)
            {
                requestIncludes_includes_KeyType = cmdletContext.Includes_KeyType;
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
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxItem.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxItem;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
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
                    int _receivedThisCall = response.CertificateSummaryList.Count;
                    
                    _nextToken = response.NextToken;
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
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
            public List<System.String> CertificateStatus { get; set; }
            public List<System.String> Includes_ExtendedKeyUsage { get; set; }
            public List<System.String> Includes_KeyType { get; set; }
            public List<System.String> Includes_KeyUsage { get; set; }
            public int? MaxItem { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.CertificateManager.SortBy SortBy { get; set; }
            public Amazon.CertificateManager.SortOrder SortOrder { get; set; }
            public System.Func<Amazon.CertificateManager.Model.ListCertificatesResponse, GetACMCertificateListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CertificateSummaryList;
        }
        
    }
}
