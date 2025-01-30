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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Returns descriptions for existing environments.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EBEnvironment")]
    [OutputType("Amazon.ElasticBeanstalk.Model.EnvironmentDescription")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk DescribeEnvironments API operation.", Operation = new[] {"DescribeEnvironments"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsResponse))]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.EnvironmentDescription or Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsResponse",
        "This cmdlet returns a collection of Amazon.ElasticBeanstalk.Model.EnvironmentDescription objects.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEBEnvironmentCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para>If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that are associated with this application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that have the specified IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentIds")]
        public System.String[] EnvironmentId { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that have the specified names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentNames")]
        public System.String[] EnvironmentName { get; set; }
        #endregion
        
        #region Parameter UtcIncludedDeletedBackTo
        /// <summary>
        /// <para>
        /// <para> If specified when <c>IncludeDeleted</c> is set to <c>true</c>, then environments
        /// deleted after this date are displayed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcIncludedDeletedBackTo { get; set; }
        #endregion
        
        #region Parameter IncludeDeleted
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include deleted environments:</para><para><c>true</c>: Environments that have been deleted after <c>IncludedDeletedBackTo</c>
        /// are displayed.</para><para><c>false</c>: Do not include deleted environments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeDeleted { get; set; }
        #endregion
        
        #region Parameter VersionLabel
        /// <summary>
        /// <para>
        /// <para>If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those that are associated with this application version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String VersionLabel { get; set; }
        #endregion
        
        #region Parameter IncludedDeletedBackTo
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use IncludedDeletedBackToUtc instead. Setting either IncludedDeletedBackTo
        /// or IncludedDeletedBackToUtc results in both IncludedDeletedBackTo and IncludedDeletedBackToUtc
        /// being assigned, the latest assignment to either one of the two property is reflected
        /// in the value of both. IncludedDeletedBackTo is provided for backwards compatibility
        /// only and assigning a non-Utc DateTime to it results in the wrong timestamp being passed
        /// to the service.</para><para> If specified when <c>IncludeDeleted</c> is set to <c>true</c>, then environments
        /// deleted after this date are displayed. </para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcIncludedDeletedBackTo instead.")]
        public System.DateTime? IncludedDeletedBackTo { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para>For a paginated request. Specify a maximum number of environments to include in each
        /// response.</para><para>If no <c>MaxRecords</c> is specified, all available environments are retrieved in
        /// a single response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>1000</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxRecords")]
        public int? MaxRecord { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>For a paginated request. Specify a token from a previous response page to retrieve
        /// the next response page. All other parameter values must be identical to the ones specified
        /// in the initial request.</para><para>If no <c>NextToken</c> is specified, the first page is retrieved.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Environments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsResponse).
        /// Specifying the name of a property of type Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Environments";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsResponse, GetEBEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationName = this.ApplicationName;
            if (this.EnvironmentId != null)
            {
                context.EnvironmentId = new List<System.String>(this.EnvironmentId);
            }
            if (this.EnvironmentName != null)
            {
                context.EnvironmentName = new List<System.String>(this.EnvironmentName);
            }
            context.UtcIncludedDeletedBackTo = this.UtcIncludedDeletedBackTo;
            context.IncludeDeleted = this.IncludeDeleted;
            context.MaxRecord = this.MaxRecord;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxRecord)))
            {
                WriteVerbose("MaxRecord parameter unset, using default value of '1000'");
                context.MaxRecord = 1000;
            }
            #endif
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxRecord)) && this.MaxRecord.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxRecord parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxRecord" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.VersionLabel = this.VersionLabel;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IncludedDeletedBackTo = this.IncludedDeletedBackTo;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentIds = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentNames = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.UtcIncludedDeletedBackTo != null)
            {
                request.IncludedDeletedBackToUtc = cmdletContext.UtcIncludedDeletedBackTo.Value;
            }
            if (cmdletContext.IncludeDeleted != null)
            {
                request.IncludeDeleted = cmdletContext.IncludeDeleted.Value;
            }
            if (cmdletContext.MaxRecord != null)
            {
                request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxRecord.Value);
            }
            if (cmdletContext.VersionLabel != null)
            {
                request.VersionLabel = cmdletContext.VersionLabel;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.IncludedDeletedBackTo != null)
            {
                if (cmdletContext.UtcIncludedDeletedBackTo != null)
                {
                    throw new System.ArgumentException("Parameters IncludedDeletedBackTo and UtcIncludedDeletedBackTo are mutually exclusive.", nameof(this.IncludedDeletedBackTo));
                }
                request.IncludedDeletedBackTo = cmdletContext.IncludedDeletedBackTo.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsRequest();
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentIds = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentNames = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.UtcIncludedDeletedBackTo != null)
            {
                request.IncludedDeletedBackToUtc = cmdletContext.UtcIncludedDeletedBackTo.Value;
            }
            if (cmdletContext.IncludeDeleted != null)
            {
                request.IncludeDeleted = cmdletContext.IncludeDeleted.Value;
            }
            if (cmdletContext.VersionLabel != null)
            {
                request.VersionLabel = cmdletContext.VersionLabel;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.IncludedDeletedBackTo != null)
            {
                if (cmdletContext.UtcIncludedDeletedBackTo != null)
                {
                    throw new System.ArgumentException("Parameters IncludedDeletedBackTo and UtcIncludedDeletedBackTo are mutually exclusive.", nameof(this.IncludedDeletedBackTo));
                }
                request.IncludedDeletedBackTo = cmdletContext.IncludedDeletedBackTo.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxRecord.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxRecord;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxRecord)))
                {
                    request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(1000);
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
                    int _receivedThisCall = response.Environments.Count;
                    
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
        
        private Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "DescribeEnvironments");
            try
            {
                #if DESKTOP
                return client.DescribeEnvironments(request);
                #elif CORECLR
                return client.DescribeEnvironmentsAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public List<System.String> EnvironmentId { get; set; }
            public List<System.String> EnvironmentName { get; set; }
            public System.DateTime? UtcIncludedDeletedBackTo { get; set; }
            public System.Boolean? IncludeDeleted { get; set; }
            public int? MaxRecord { get; set; }
            public System.String NextToken { get; set; }
            public System.String VersionLabel { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? IncludedDeletedBackTo { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.DescribeEnvironmentsResponse, GetEBEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Environments;
        }
        
    }
}
