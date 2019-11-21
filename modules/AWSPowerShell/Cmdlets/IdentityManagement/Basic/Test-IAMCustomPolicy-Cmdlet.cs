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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Simulate how a set of IAM policies and optionally a resource-based policy works with
    /// a list of API operations and AWS resources to determine the policies' effective permissions.
    /// The policies are provided as strings.
    /// 
    ///  
    /// <para>
    /// The simulation does not perform the API operations; it only checks the authorization
    /// to determine if the simulated policies allow or deny the operations.
    /// </para><para>
    /// If you want to simulate existing policies attached to an IAM user, group, or role,
    /// use <a>SimulatePrincipalPolicy</a> instead.
    /// </para><para>
    /// Context keys are variables maintained by AWS and its services that provide details
    /// about the context of an API query request. You can use the <code>Condition</code>
    /// element of an IAM policy to evaluate context keys. To get the list of context keys
    /// that the policies require for correct simulation, use <a>GetContextKeysForCustomPolicy</a>.
    /// </para><para>
    /// If the output is long, you can use <code>MaxItems</code> and <code>Marker</code> parameters
    /// to paginate the results.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Test", "IAMCustomPolicy")]
    [OutputType("Amazon.IdentityManagement.Model.EvaluationResult")]
    [AWSCmdlet("Calls the AWS Identity and Access Management SimulateCustomPolicy API operation.", Operation = new[] {"SimulateCustomPolicy"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.SimulateCustomPolicyResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.EvaluationResult or Amazon.IdentityManagement.Model.SimulateCustomPolicyResponse",
        "This cmdlet returns a collection of Amazon.IdentityManagement.Model.EvaluationResult objects.",
        "The service call response (type Amazon.IdentityManagement.Model.SimulateCustomPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestIAMCustomPolicyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ActionName
        /// <summary>
        /// <para>
        /// <para>A list of names of API operations to evaluate in the simulation. Each operation is
        /// evaluated against each resource. Each operation must include the service identifier,
        /// such as <code>iam:CreateUser</code>. This operation does not support using wildcards
        /// (*) in an action name.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ActionNames")]
        public System.String[] ActionName { get; set; }
        #endregion
        
        #region Parameter CallerArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM user that you want to use as the simulated caller of the API operations.
        /// <code>CallerArn</code> is required if you include a <code>ResourcePolicy</code> so
        /// that the policy's <code>Principal</code> element has a value to use in evaluating
        /// the policy.</para><para>You can specify only the ARN of an IAM user. You cannot specify the ARN of an assumed
        /// role, federated user, or a service principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CallerArn { get; set; }
        #endregion
        
        #region Parameter ContextEntry
        /// <summary>
        /// <para>
        /// <para>A list of context keys and corresponding values for the simulation to use. Whenever
        /// a context key is evaluated in one of the simulated IAM permissions policies, the corresponding
        /// value is supplied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContextEntries")]
        public Amazon.IdentityManagement.Model.ContextEntry[] ContextEntry { get; set; }
        #endregion
        
        #region Parameter PolicyInputList
        /// <summary>
        /// <para>
        /// <para>A list of policy documents to include in the simulation. Each document is specified
        /// as a string containing the complete, valid JSON text of an IAM policy. Do not include
        /// any resource-based policies in this parameter. Any resource-based policy must be submitted
        /// with the <code>ResourcePolicy</code> parameter. The policies cannot be "scope-down"
        /// policies, such as you could include in a call to <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_GetFederationToken.html">GetFederationToken</a>
        /// or one of the <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_AssumeRole.html">AssumeRole</a>
        /// API operations. In other words, do not use policies designed to restrict what a user
        /// can do while using the temporary credentials.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> used to validate this
        /// parameter is a string of characters consisting of the following:</para><ul><li><para>Any printable ASCII character ranging from the space character (\u0020) through the
        /// end of the ASCII character range</para></li><li><para>The printable characters in the Basic Latin and Latin-1 Supplement character set (through
        /// \u00FF)</para></li><li><para>The special characters tab (\u0009), line feed (\u000A), and carriage return (\u000D)</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] PolicyInputList { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>A list of ARNs of AWS resources to include in the simulation. If this parameter is
        /// not provided, then the value defaults to <code>*</code> (all resources). Each API
        /// in the <code>ActionNames</code> parameter is evaluated for each resource in this list.
        /// The simulation determines the access result (allowed or denied) of each combination
        /// and reports it in the response.</para><para>The simulation does not automatically retrieve policies for the specified resources.
        /// If you want to include a resource policy in the simulation, then you must include
        /// the policy as a string in the <code>ResourcePolicy</code> parameter.</para><para>If you include a <code>ResourcePolicy</code>, then it must be applicable to all of
        /// the resources included in the simulation or you receive an invalid input error.</para><para>For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a> in the <i>AWS General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter ResourceHandlingOption
        /// <summary>
        /// <para>
        /// <para>Specifies the type of simulation to run. Different API operations that support resource-based
        /// policies require different combinations of resources. By specifying the type of simulation
        /// to run, you enable the policy simulator to enforce the presence of the required resources
        /// to ensure reliable simulation results. If your simulation does not match one of the
        /// following scenarios, then you can omit this parameter. The following list shows each
        /// of the supported scenario values and the resources that you must define to run the
        /// simulation.</para><para>Each of the EC2 scenarios requires that you specify instance, image, and security-group
        /// resources. If your scenario includes an EBS volume, then you must specify that volume
        /// as a resource. If the EC2 scenario includes VPC, then you must supply the network-interface
        /// resource. If it includes an IP subnet, then you must specify the subnet resource.
        /// For more information on the EC2 scenario options, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-supported-platforms.html">Supported
        /// Platforms</a> in the <i>Amazon EC2 User Guide</i>.</para><ul><li><para><b>EC2-Classic-InstanceStore</b></para><para>instance, image, security-group</para></li><li><para><b>EC2-Classic-EBS</b></para><para>instance, image, security-group, volume</para></li><li><para><b>EC2-VPC-InstanceStore</b></para><para>instance, image, security-group, network-interface</para></li><li><para><b>EC2-VPC-InstanceStore-Subnet</b></para><para>instance, image, security-group, network-interface, subnet</para></li><li><para><b>EC2-VPC-EBS</b></para><para>instance, image, security-group, network-interface, volume</para></li><li><para><b>EC2-VPC-EBS-Subnet</b></para><para>instance, image, security-group, network-interface, subnet, volume</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceHandlingOption { get; set; }
        #endregion
        
        #region Parameter ResourceOwner
        /// <summary>
        /// <para>
        /// <para>An ARN representing the AWS account ID that specifies the owner of any simulated resource
        /// that does not identify its owner in the resource ARN. Examples of resource ARNs include
        /// an S3 bucket or object. If <code>ResourceOwner</code> is specified, it is also used
        /// as the account owner of any <code>ResourcePolicy</code> included in the simulation.
        /// If the <code>ResourceOwner</code> parameter is not specified, then the owner of the
        /// resources and the resource policy defaults to the account of the identity provided
        /// in <code>CallerArn</code>. This parameter is required only if you specify a resource-based
        /// policy and account that owns the resource is different from the account that owns
        /// the simulated calling user <code>CallerArn</code>.</para><para>The ARN for an account uses the following syntax: <code>arn:aws:iam::<i>AWS-account-ID</i>:root</code>.
        /// For example, to represent the account with the 112233445566 ID, use the following
        /// ARN: <code>arn:aws:iam::112233445566-ID:root</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceOwner { get; set; }
        #endregion
        
        #region Parameter ResourcePolicy
        /// <summary>
        /// <para>
        /// <para>A resource-based policy to include in the simulation provided as a string. Each resource
        /// in the simulation is treated as if it had this policy attached. You can include only
        /// one resource-based policy in a simulation.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> used to validate this
        /// parameter is a string of characters consisting of the following:</para><ul><li><para>Any printable ASCII character ranging from the space character (\u0020) through the
        /// end of the ASCII character range</para></li><li><para>The printable characters in the Basic Latin and Latin-1 Supplement character set (through
        /// \u00FF)</para></li><li><para>The special characters tab (\u0009), line feed (\u000A), and carriage return (\u000D)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourcePolicy { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this parameter only when paginating results and only after you receive a response
        /// indicating that the results are truncated. Set it to the value of the <code>Marker</code>
        /// element in the response that you received to indicate where the next call should start.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-Marker $null' for the first call and '-Marker $AWSHistory.LastServiceResponse.Marker' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Use this only when paginating results to indicate the maximum number of items you
        /// want in the response. If additional items exist beyond the maximum you specify, the
        /// <code>IsTruncated</code> response element is <code>true</code>.</para><para>If you do not include this parameter, the number of items defaults to 100. Note that
        /// IAM might return fewer results, even when there are more results available. In that
        /// case, the <code>IsTruncated</code> response element returns <code>true</code>, and
        /// <code>Marker</code> contains a value to include in the subsequent call that tells
        /// the service where to continue from.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EvaluationResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.SimulateCustomPolicyResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.SimulateCustomPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EvaluationResults";
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.SimulateCustomPolicyResponse, TestIAMCustomPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ActionName != null)
            {
                context.ActionName = new List<System.String>(this.ActionName);
            }
            #if MODULAR
            if (this.ActionName == null && ParameterWasBound(nameof(this.ActionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CallerArn = this.CallerArn;
            if (this.ContextEntry != null)
            {
                context.ContextEntry = new List<Amazon.IdentityManagement.Model.ContextEntry>(this.ContextEntry);
            }
            context.Marker = this.Marker;
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
            if (this.PolicyInputList != null)
            {
                context.PolicyInputList = new List<System.String>(this.PolicyInputList);
            }
            #if MODULAR
            if (this.PolicyInputList == null && ParameterWasBound(nameof(this.PolicyInputList)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyInputList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceArn != null)
            {
                context.ResourceArn = new List<System.String>(this.ResourceArn);
            }
            context.ResourceHandlingOption = this.ResourceHandlingOption;
            context.ResourceOwner = this.ResourceOwner;
            context.ResourcePolicy = this.ResourcePolicy;
            
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
            var request = new Amazon.IdentityManagement.Model.SimulateCustomPolicyRequest();
            
            if (cmdletContext.ActionName != null)
            {
                request.ActionNames = cmdletContext.ActionName;
            }
            if (cmdletContext.CallerArn != null)
            {
                request.CallerArn = cmdletContext.CallerArn;
            }
            if (cmdletContext.ContextEntry != null)
            {
                request.ContextEntries = cmdletContext.ContextEntry;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxItem.Value);
            }
            if (cmdletContext.PolicyInputList != null)
            {
                request.PolicyInputList = cmdletContext.PolicyInputList;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            if (cmdletContext.ResourceHandlingOption != null)
            {
                request.ResourceHandlingOption = cmdletContext.ResourceHandlingOption;
            }
            if (cmdletContext.ResourceOwner != null)
            {
                request.ResourceOwner = cmdletContext.ResourceOwner;
            }
            if (cmdletContext.ResourcePolicy != null)
            {
                request.ResourcePolicy = cmdletContext.ResourcePolicy;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.IdentityManagement.Model.SimulateCustomPolicyRequest();
            if (cmdletContext.ActionName != null)
            {
                request.ActionNames = cmdletContext.ActionName;
            }
            if (cmdletContext.CallerArn != null)
            {
                request.CallerArn = cmdletContext.CallerArn;
            }
            if (cmdletContext.ContextEntry != null)
            {
                request.ContextEntries = cmdletContext.ContextEntry;
            }
            if (cmdletContext.PolicyInputList != null)
            {
                request.PolicyInputList = cmdletContext.PolicyInputList;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            if (cmdletContext.ResourceHandlingOption != null)
            {
                request.ResourceHandlingOption = cmdletContext.ResourceHandlingOption;
            }
            if (cmdletContext.ResourceOwner != null)
            {
                request.ResourceOwner = cmdletContext.ResourceOwner;
            }
            if (cmdletContext.ResourcePolicy != null)
            {
                request.ResourcePolicy = cmdletContext.ResourcePolicy;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextToken = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxItem))
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxItem;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = AutoIterationHelpers.Min(1000, _emitLimit.Value);
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
                    int _receivedThisCall = response.EvaluationResults.Count;
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.IdentityManagement.Model.SimulateCustomPolicyResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.SimulateCustomPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "SimulateCustomPolicy");
            try
            {
                #if DESKTOP
                return client.SimulateCustomPolicy(request);
                #elif CORECLR
                return client.SimulateCustomPolicyAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ActionName { get; set; }
            public System.String CallerArn { get; set; }
            public List<Amazon.IdentityManagement.Model.ContextEntry> ContextEntry { get; set; }
            public System.String Marker { get; set; }
            public int? MaxItem { get; set; }
            public List<System.String> PolicyInputList { get; set; }
            public List<System.String> ResourceArn { get; set; }
            public System.String ResourceHandlingOption { get; set; }
            public System.String ResourceOwner { get; set; }
            public System.String ResourcePolicy { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.SimulateCustomPolicyResponse, TestIAMCustomPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EvaluationResults;
        }
        
    }
}
