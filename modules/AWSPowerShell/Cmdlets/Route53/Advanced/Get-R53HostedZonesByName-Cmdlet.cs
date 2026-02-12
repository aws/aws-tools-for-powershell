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
using Amazon.Route53;
using Amazon.Route53.Model;
using System.Threading;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Retrieves a list of your hosted zones in lexicographic order. The response includes
    /// a <code>HostedZones</code> child element for each hosted zone created by the current
    /// AWS account. 
    /// 
    ///  
    /// <para><code>ListHostedZonesByName</code> sorts hosted zones by name with the labels reversed.
    /// For example:
    /// </para><para><code>com.example.www.</code></para><para>
    /// Note the trailing dot, which can change the sort order in some circumstances.
    /// </para><para>
    /// If the domain name includes escape characters or Punycode, <code>ListHostedZonesByName</code>
    /// alphabetizes the domain name using the escaped or Punycoded value, which is the format
    /// that Amazon Route 53 saves in its database. For example, to create a hosted zone for
    /// ex�mple.com, you specify ex\344mple.com for the domain name. <code>ListHostedZonesByName</code>
    /// alphabetizes it as:
    /// </para><para><code>com.ex\344mple.</code></para><para>
    /// The labels are reversed and alphabetized using the escaped value. For more information
    /// about valid domain name formats, including internationalized domain names, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/DomainNameFormat.html">DNS
    /// Domain Name Format</a> in the <i>Amazon Route 53 Developer Guide</i>.
    /// </para><para>
    /// Route 53 returns up to 100 items in each response. If you have a lot of hosted zones,
    /// use the <code>MaxItems</code> parameter to list them in groups of up to 100. The response
    /// includes values that help navigate from one group of <code>MaxItems</code> hosted
    /// zones to the next:
    /// </para><ul><li><para>
    /// The <code>DNSName</code> and <code>HostedZoneId</code> elements in the response contain
    /// the values, if any, specified for the <code>dnsname</code> and <code>hostedzoneid</code>
    /// parameters in the request that produced the current response.
    /// </para></li><li><para>
    /// The <code>MaxItems</code> element in the response contains the value, if any, that
    /// you specified for the <code>maxitems</code> parameter in the request that produced
    /// the current response.
    /// </para></li><li><para>
    /// If the value of <code>IsTruncated</code> in the response is true, there are more hosted
    /// zones associated with the current AWS account. 
    /// </para><para>
    /// If <code>IsTruncated</code> is false, this response includes the last hosted zone
    /// that is associated with the current account. The <code>NextDNSName</code> element
    /// and <code>NextHostedZoneId</code> elements are omitted from the response.
    /// </para></li><li><para>
    /// The <code>NextDNSName</code> and <code>NextHostedZoneId</code> elements in the response
    /// contain the domain name and the hosted zone ID of the next hosted zone that is associated
    /// with the current AWS account. If you want to list more hosted zones, make another
    /// call to <code>ListHostedZonesByName</code>, and specify the value of <code>NextDNSName</code>
    /// and <code>NextHostedZoneId</code> in the <code>dnsname</code> and <code>hostedzoneid</code>
    /// parameters, respectively.
    /// </para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "R53HostedZonesByName")]
    [OutputType("Amazon.Route53.Model.HostedZone")]
    [AWSCmdlet("Calls the Amazon Route 53 ListHostedZonesByName API operation.", Operation = new[] { "ListHostedZonesByName" }, SelectReturnType = typeof(Amazon.Route53.Model.ListHostedZonesByNameResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.HostedZone or Amazon.Route53.Model.ListHostedZonesByNameResponse",
        "This cmdlet returns a collection of Amazon.Route53.Model.HostedZone objects.",
        "The service call response (type Amazon.Route53.Model.ListHostedZonesByNameResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53HostedZonesByNameCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();


        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>(Optional) For your first request to <code>ListHostedZonesByName</code>, do not include
        /// the <code>hostedzoneid</code> parameter.</para><para>If you have more hosted zones than the value of <code>maxitems</code>, <code>ListHostedZonesByName</code>
        /// returns only the first <code>maxitems</code> hosted zones. To get the next group of
        /// <code>maxitems</code> hosted zones, submit another request to <code>ListHostedZonesByName</code>
        /// and include both <code>dnsname</code> and <code>hostedzoneid</code> parameters. For
        /// the value of <code>hostedzoneid</code>, specify the value of the <code>NextHostedZoneId</code>
        /// element from the previous response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>HostedZoneId is only output from the cmdlet when <code>-Select *</code> is specified. In order to manually control output pagination, set '-HostedZoneId' to null for the first call then input the 'NextHostedZoneId' output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostedZoneId { get; set; }
        #endregion

        #region Parameter DNSName
        /// <summary>
        /// <para>
        /// <para>(Optional) For your first request to <code>ListHostedZonesByName</code>, include the
        /// <code>dnsname</code> parameter only if you want to specify the name of the first hosted
        /// zone in the response. If you don't include the <code>dnsname</code> parameter, Amazon
        /// Route 53 returns all of the hosted zones that were created by the current AWS account,
        /// in ASCII order. For subsequent requests, include both <code>dnsname</code> and <code>hostedzoneid</code>
        /// parameters. For <code>dnsname</code>, specify the value of <code>NextDNSName</code>
        /// from the previous response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-DNSName $null' for the first call and '-DNSName $AWSHistory.LastServiceResponse.NextDNSName' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String DNSName { get; set; }
        #endregion

        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of hosted zones to be included in the response body for this request.
        /// If you have more than <code>maxitems</code> hosted zones, then the value of the <code>IsTruncated</code>
        /// element in the response is true, and the values of <code>NextDNSName</code> and <code>NextHostedZoneId</code>
        /// specify the first hosted zone in the next group of <code>maxitems</code> hosted zones.
        /// </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int? MaxItem { get; set; }
        #endregion

        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HostedZones'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListHostedZonesByNameResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListHostedZonesByNameResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter]
        public string Select { get; set; } = "HostedZones";
        #endregion

        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of DNSName
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter]
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
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListHostedZonesByNameResponse, GetR53HostedZonesByNameCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DNSName = this.DNSName;
            context.HostedZoneId = this.HostedZoneId;
#if !MODULAR
            if (ParameterWasBound(nameof(this.MaxItem)))
#endif
            {
                context.MaxItem = this.MaxItem;
            }

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
            var useParameterSelect = this.Select.StartsWith(".");

            // create request and set iteration invariants
            var request = new Amazon.Route53.Model.ListHostedZonesByNameRequest();

            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToServiceTypeString(cmdletContext.MaxItem.Value);
            }

            // Initialize loop variant and commence piping
            string _nextDNSName = cmdletContext.DNSName;
            string _nextHostedZoneId = cmdletContext.HostedZoneId;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.DNSName)) || ParameterWasBound(nameof(this.HostedZoneId));

            try
            {
                var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
                do
                {
                    request.DNSName = _nextDNSName;
                    request.HostedZoneId = _nextHostedZoneId;

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
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = (pipelineOutput as System.Collections.ICollection)?.Count ?? 1;
                            WriteProgressRecord("Retrieving", $"Retrieved {_receivedThisCall} records starting from marker '{request.DNSName ?? "null"}, {request.HostedZoneId ?? "null"}'");
                        }

                        _nextDNSName = response.NextDNSName;
                        _nextHostedZoneId = response.NextHostedZoneId;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }

                    ProcessOutput(output);

                } while (!_userControllingPaging && (AutoIterationHelpers.HasValue(_nextDNSName) || AutoIterationHelpers.HasValue(_nextHostedZoneId)));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }

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
            var useParameterSelect = this.Select.StartsWith(".");
            
            // create request and set iteration invariants
            var request = new Amazon.Route53.Model.ListHostedZonesByNameRequest();
            
            // Initialize loop variants and commence piping
            string _nextDNSName = null;
            string _nextHostedZoneId = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.DNSName) || AutoIterationHelpers.HasValue(cmdletContext.HostedZoneId))
            {
                _nextDNSName = cmdletContext.DNSName;
                _nextHostedZoneId = cmdletContext.HostedZoneId;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxItem))
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxItem;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.DNSName)) || ParameterWasBound(nameof(this.HostedZoneId));
            
            try
            {
                var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
                do
                {
                    request.DNSName = _nextDNSName;
                    request.HostedZoneId = _nextHostedZoneId;
                    if (_emitLimit.HasValue)
                    {
                        int correctPageSize = Math.Min(100, _emitLimit.Value);
                        request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToString(correctPageSize);
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
                        int _receivedThisCall = response.HostedZones?.Count ?? 0;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", $"Retrieved {_receivedThisCall} records starting from marker '{request.DNSName ?? "null"}, {request.HostedZoneId ?? "null"}'");
                        }

                        _nextDNSName = response.NextDNSName;
                        _nextHostedZoneId = response.NextHostedZoneId;
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
                } while (!_userControllingPaging && (AutoIterationHelpers.HasValue(_nextDNSName) || AutoIterationHelpers.HasValue(_nextHostedZoneId)) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
            }
            finally
            {
            }
            
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

        private Amazon.Route53.Model.ListHostedZonesByNameResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListHostedZonesByNameRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListHostedZonesByName");
            try
            {
                return client.ListHostedZonesByNameAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();

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
            public System.String DNSName { get; set; }
            public System.String HostedZoneId { get; set; }
            public int? MaxItem { get; set; }
            public System.Func<Amazon.Route53.Model.ListHostedZonesByNameResponse, GetR53HostedZonesByNameCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HostedZones;
        }

    }
}
