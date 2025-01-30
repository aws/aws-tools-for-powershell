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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Describes an endpoint authorization.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "RSEndpointAuthorization")]
    [OutputType("Amazon.Redshift.Model.EndpointAuthorization")]
    [AWSCmdlet("Calls the Amazon Redshift DescribeEndpointAuthorization API operation.", Operation = new[] {"DescribeEndpointAuthorization"}, SelectReturnType = typeof(Amazon.Redshift.Model.DescribeEndpointAuthorizationResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.EndpointAuthorization or Amazon.Redshift.Model.DescribeEndpointAuthorizationResponse",
        "This cmdlet returns a collection of Amazon.Redshift.Model.EndpointAuthorization objects.",
        "The service call response (type Amazon.Redshift.Model.DescribeEndpointAuthorizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRSEndpointAuthorizationCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Account
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of either the cluster owner (grantor) or grantee.
        /// If <c>Grantee</c> parameter is true, then the <c>Account</c> value is of the grantor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Account { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The cluster identifier of the cluster to access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Grantee
        /// <summary>
        /// <para>
        /// <para>Indicates whether to check authorization from a grantor or grantee point of view.
        /// If true, Amazon Redshift returns endpoint authorizations that you've been granted.
        /// If false (default), checks authorization from a grantor point of view.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Grantee { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous <c>DescribeEndpointAuthorization</c>
        /// request. If this parameter is specified, the response includes only records beyond
        /// the marker, up to the value specified by the <c>MaxRecords</c> parameter.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in the response. If more records exist than
        /// the specified <c>MaxRecords</c> value, a pagination token called a <c>Marker</c> is
        /// included in the response so that the remaining results can be retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRecords")]
        public System.Int32? MaxRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EndpointAuthorizationList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.DescribeEndpointAuthorizationResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.DescribeEndpointAuthorizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointAuthorizationList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.DescribeEndpointAuthorizationResponse, GetRSEndpointAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Account = this.Account;
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.Grantee = this.Grantee;
            context.Marker = this.Marker;
            context.MaxRecord = this.MaxRecord;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Redshift.Model.DescribeEndpointAuthorizationRequest();
            
            if (cmdletContext.Account != null)
            {
                request.Account = cmdletContext.Account;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.Grantee != null)
            {
                request.Grantee = cmdletContext.Grantee.Value;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = cmdletContext.MaxRecord.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.Redshift.Model.DescribeEndpointAuthorizationResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.DescribeEndpointAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "DescribeEndpointAuthorization");
            try
            {
                #if DESKTOP
                return client.DescribeEndpointAuthorization(request);
                #elif CORECLR
                return client.DescribeEndpointAuthorizationAsync(request).GetAwaiter().GetResult();
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
            public System.String Account { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.Boolean? Grantee { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxRecord { get; set; }
            public System.Func<Amazon.Redshift.Model.DescribeEndpointAuthorizationResponse, GetRSEndpointAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointAuthorizationList;
        }
        
    }
}
