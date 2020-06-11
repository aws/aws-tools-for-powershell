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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes one or more versions of a specified launch template. You can describe all
    /// versions, individual versions, or a range of versions. You can also describe all the
    /// latest versions or all the default versions of all the launch templates in your account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2TemplateVersion")]
    [OutputType("Amazon.EC2.Model.LaunchTemplateVersion")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeLaunchTemplateVersions API operation.", Operation = new[] {"DescribeLaunchTemplateVersions"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeLaunchTemplateVersionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.LaunchTemplateVersion or Amazon.EC2.Model.DescribeLaunchTemplateVersionsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.LaunchTemplateVersion objects.",
        "The service call response (type Amazon.EC2.Model.DescribeLaunchTemplateVersionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2TemplateVersionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>create-time</code> - The time the launch template version was created.</para></li><li><para><code>ebs-optimized</code> - A boolean that indicates whether the instance is optimized
        /// for Amazon EBS I/O.</para></li><li><para><code>iam-instance-profile</code> - The ARN of the IAM instance profile.</para></li><li><para><code>image-id</code> - The ID of the AMI.</para></li><li><para><code>instance-type</code> - The instance type.</para></li><li><para><code>is-default-version</code> - A boolean that indicates whether the launch template
        /// version is the default version.</para></li><li><para><code>kernel-id</code> - The kernel ID.</para></li><li><para><code>ram-disk-id</code> - The RAM disk ID.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template. To describe one or more versions of a specified launch
        /// template, you must specify either the launch template ID or the launch template name
        /// in the request. To describe all the latest or default launch template versions in
        /// your account, you must omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template. To describe one or more versions of a specified launch
        /// template, you must specify either the launch template ID or the launch template name
        /// in the request. To describe all the latest or default launch template versions in
        /// your account, you must omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter MaxVersion
        /// <summary>
        /// <para>
        /// <para>The version number up to which to describe launch template versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaxVersion { get; set; }
        #endregion
        
        #region Parameter MinVersion
        /// <summary>
        /// <para>
        /// <para>The version number after which to describe launch template versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MinVersion { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>One or more versions of the launch template. Valid values depend on whether you are
        /// describing a specified launch template (by ID or name) or all launch templates in
        /// your account.</para><para>To describe one or more versions of a specified launch template, valid values are
        /// <code>$Latest</code>, <code>$Default</code>, and numbers.</para><para>To describe all launch templates in your account that are defined as the latest version,
        /// the valid value is <code>$Latest</code>. To describe all launch templates in your
        /// account that are defined as the default version, the valid value is <code>$Default</code>.
        /// You can specify <code>$Latest</code> and <code>$Default</code> in the same call. You
        /// cannot specify numbers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Versions")]
        public System.String[] Version { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. To retrieve the remaining
        /// results, make another call with the returned <code>NextToken</code> value. This value
        /// can be between 1 and 200.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to request the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LaunchTemplateVersions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeLaunchTemplateVersionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeLaunchTemplateVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LaunchTemplateVersions";
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeLaunchTemplateVersionsResponse, GetEC2TemplateVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.LaunchTemplateId = this.LaunchTemplateId;
            context.LaunchTemplateName = this.LaunchTemplateName;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.MaxVersion = this.MaxVersion;
            context.MinVersion = this.MinVersion;
            context.NextToken = this.NextToken;
            if (this.Version != null)
            {
                context.Version = new List<System.String>(this.Version);
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeLaunchTemplateVersionsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.LaunchTemplateId != null)
            {
                request.LaunchTemplateId = cmdletContext.LaunchTemplateId;
            }
            if (cmdletContext.LaunchTemplateName != null)
            {
                request.LaunchTemplateName = cmdletContext.LaunchTemplateName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.MaxVersion != null)
            {
                request.MaxVersion = cmdletContext.MaxVersion;
            }
            if (cmdletContext.MinVersion != null)
            {
                request.MinVersion = cmdletContext.MinVersion;
            }
            if (cmdletContext.Version != null)
            {
                request.Versions = cmdletContext.Version;
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
            var request = new Amazon.EC2.Model.DescribeLaunchTemplateVersionsRequest();
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.LaunchTemplateId != null)
            {
                request.LaunchTemplateId = cmdletContext.LaunchTemplateId;
            }
            if (cmdletContext.LaunchTemplateName != null)
            {
                request.LaunchTemplateName = cmdletContext.LaunchTemplateName;
            }
            if (cmdletContext.MaxVersion != null)
            {
                request.MaxVersion = cmdletContext.MaxVersion;
            }
            if (cmdletContext.MinVersion != null)
            {
                request.MinVersion = cmdletContext.MinVersion;
            }
            if (cmdletContext.Version != null)
            {
                request.Versions = cmdletContext.Version;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
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
                    int _receivedThisCall = response.LaunchTemplateVersions.Count;
                    
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
        
        private Amazon.EC2.Model.DescribeLaunchTemplateVersionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeLaunchTemplateVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeLaunchTemplateVersions");
            try
            {
                #if DESKTOP
                return client.DescribeLaunchTemplateVersions(request);
                #elif CORECLR
                return client.DescribeLaunchTemplateVersionsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.String LaunchTemplateId { get; set; }
            public System.String LaunchTemplateName { get; set; }
            public int? MaxResult { get; set; }
            public System.String MaxVersion { get; set; }
            public System.String MinVersion { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> Version { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeLaunchTemplateVersionsResponse, GetEC2TemplateVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LaunchTemplateVersions;
        }
        
    }
}
