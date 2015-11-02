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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Simulate how a set of IAM policies and optionally a resource-based policy works with
    /// a list of API actions and AWS resources to determine the policies' effective permissions.
    /// The policies are provided as strings.
    /// 
    ///  
    /// <para>
    /// The simulation does not perform the API actions; it only checks the authorization
    /// to determine if the simulated policies allow or deny the actions.
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
    /// </para>
    /// </summary>
    [Cmdlet("Test", "IAMCustomPolicy")]
    [OutputType("Amazon.IdentityManagement.Model.EvaluationResult")]
    [AWSCmdlet("Invokes the SimulateCustomPolicy operation against AWS Identity and Access Management.", Operation = new[] {"SimulateCustomPolicy"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.EvaluationResult",
        "This cmdlet returns a collection of EvaluationResult objects.",
        "The service call response (type Amazon.IdentityManagement.Model.SimulateCustomPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: IsTruncated (type System.Boolean), Marker (type System.String)"
    )]
    public class TestIAMCustomPolicyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A list of names of API actions to evaluate in the simulation. Each action is evaluated
        /// against each resource. Each action must include the service identifier, such as <code>iam:CreateUser</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ActionNames")]
        public System.String[] ActionName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of the user that you want to use as the simulated caller of the APIs. <code>CallerArn</code>
        /// is required if you include a <code>ResourcePolicy</code> so that the policy's <code>Principal</code>
        /// element has a value to use in evaluating the policy.</para><para>You can specify only the ARN of an IAM user. You cannot specify the ARN of an assumed
        /// role, federated user, or a service principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CallerArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of context keys and corresponding values for the simulation to use. Whenever
        /// a context key is evaluated by a <code>Condition</code> element in one of the simulated
        /// IAM permission policies, the corresponding value is supplied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContextEntries")]
        public Amazon.IdentityManagement.Model.ContextEntry[] ContextEntry { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of policy documents to include in the simulation. Each document is specified
        /// as a string containing the complete, valid JSON text of an IAM policy. Do not include
        /// any resource-based policies in this parameter. Any resource-based policy must be submitted
        /// with the <code>ResourcePolicy</code> parameter. The policies cannot be "scope-down"
        /// policies, such as you could include in a call to <a href="http://docs.aws.amazon.com/IAM/latest/APIReference/API_GetFederationToken.html">GetFederationToken</a>
        /// or one of the <a href="http://docs.aws.amazon.com/IAM/latest/APIReference/API_AssumeRole.html">AssumeRole</a>
        /// APIs to restrict what a user can do while using the temporary credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] PolicyInputList { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of ARNs of AWS resources to include in the simulation. If this parameter is
        /// not provided then the value defaults to <code>*</code> (all resources). Each API in
        /// the <code>ActionNames</code> parameter is evaluated for each resource in this list.
        /// The simulation determines the access result (allowed or denied) of each combination
        /// and reports it in the response.</para><para>The simulation does not automatically retrieve policies for the specified resources.
        /// If you want to include a resource policy in the simulation, then you must include
        /// the policy as a string in the <code>ResourcePolicy</code> parameter.</para><para>If you include a <code>ResourcePolicy</code>, then it must be applicable to all of
        /// the resources included in the simulation or you receive an invalid input error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the type of simulation to run. Different APIs that support resource-based
        /// policies require different combinations of resources. By specifying the type of simulation
        /// to run, you enable the policy simulator to enforce the presence of the required resources
        /// to ensure reliable simulation results. If your simulation does not match one of the
        /// following scenarios, then you can omit this parameter. The following list shows each
        /// of the supported scenario values and the resources that you must define to run the
        /// simulation.</para><para>Each of the EC2 scenarios requires that you specify instance, image, and security-group
        /// resources. If your scenario includes an EBS volume, then you must specify that volume
        /// as a resource. If the EC2 scenario includes VPC, then you must supply the network-interface
        /// resource. If it includes an IP subnet, then you must specify the subnet resource.
        /// For more information on the EC2 scenario options, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-supported-platforms.html">Supported
        /// Platforms</a> in the <i>AWS EC2 User Guide</i>.</para><ul><li><para><b>EC2-Classic-InstanceStore</b></para><para>instance, image, security-group</para></li><li><para><b>EC2-Classic-EBS</b></para><para>instance, image, security-group, volume</para></li><li><para><b>EC2-VPC-InstanceStore</b></para><para>instance, image, security-group, network-interface</para></li><li><para><b>EC2-VPC-InstanceStore-Subnet</b></para><para>instance, image, security-group, network-interface, subnet</para></li><li><para><b>EC2-VPC-EBS</b></para><para>instance, image, security-group, network-interface, volume</para></li><li><para><b>EC2-VPC-EBS-Subnet</b></para><para>instance, image, security-group, network-interface, subnet, volume</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceHandlingOption { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An AWS account ID that specifies the owner of any simulated resource that does not
        /// identify its owner in the resource ARN, such as an S3 bucket or object. If <code>ResourceOwner</code>
        /// is specified, it is also used as the account owner of any <code>ResourcePolicy</code>
        /// included in the simulation. If the <code>ResourceOwner</code> parameter is not specified,
        /// then the owner of the resources and the resource policy defaults to the account of
        /// the identity provided in <code>CallerArn</code>. This parameter is required only if
        /// you specify a resource-based policy and account that owns the resource is different
        /// from the account that owns the simulated calling user <code>CallerArn</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceOwner { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A resource-based policy to include in the simulation provided as a string. Each resource
        /// in the simulation is treated as if it had this policy attached. You can include only
        /// one resource-based policy in a simulation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourcePolicy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Use this parameter only when paginating results and only after you receive a response
        /// indicating that the results are truncated. Set it to the value of the <code>Marker</code>
        /// element in the response that you received to indicate where the next call should start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Use this only when paginating results to indicate the maximum number of items you
        /// want in the response. If additional items exist beyond the maximum you specify, the
        /// <code>IsTruncated</code> response element is <code>true</code>.</para><para>This parameter is optional. If you do not include it, it defaults to 100. Note that
        /// IAM might return fewer results, even when there are more results available. In that
        /// case, the <code>IsTruncated</code> response element returns <code>true</code> and
        /// <code>Marker</code> contains a value to include in the subsequent call that tells
        /// the service where to continue from. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ActionName != null)
            {
                context.ActionNames = new List<System.String>(this.ActionName);
            }
            context.CallerArn = this.CallerArn;
            if (this.ContextEntry != null)
            {
                context.ContextEntries = new List<Amazon.IdentityManagement.Model.ContextEntry>(this.ContextEntry);
            }
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            if (this.PolicyInputList != null)
            {
                context.PolicyInputList = new List<System.String>(this.PolicyInputList);
            }
            if (this.ResourceArn != null)
            {
                context.ResourceArns = new List<System.String>(this.ResourceArn);
            }
            context.ResourceHandlingOption = this.ResourceHandlingOption;
            context.ResourceOwner = this.ResourceOwner;
            context.ResourcePolicy = this.ResourcePolicy;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.IdentityManagement.Model.SimulateCustomPolicyRequest();
            if (cmdletContext.ActionNames != null)
            {
                request.ActionNames = cmdletContext.ActionNames;
            }
            if (cmdletContext.CallerArn != null)
            {
                request.CallerArn = cmdletContext.CallerArn;
            }
            if (cmdletContext.ContextEntries != null)
            {
                request.ContextEntries = cmdletContext.ContextEntries;
            }
            if (cmdletContext.PolicyInputList != null)
            {
                request.PolicyInputList = cmdletContext.PolicyInputList;
            }
            if (cmdletContext.ResourceArns != null)
            {
                request.ResourceArns = cmdletContext.ResourceArns;
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxItems))
            {
                _emitLimit = cmdletContext.MaxItems;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.Marker) || AutoIterationHelpers.HasValue(cmdletContext.MaxItems);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.SimulateCustomPolicy(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.EvaluationResults;
                        notes = new Dictionary<string, object>();
                        notes["IsTruncated"] = response.IsTruncated;
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.EvaluationResults.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
                        
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> ActionNames { get; set; }
            public System.String CallerArn { get; set; }
            public List<Amazon.IdentityManagement.Model.ContextEntry> ContextEntries { get; set; }
            public System.String Marker { get; set; }
            public int? MaxItems { get; set; }
            public List<System.String> PolicyInputList { get; set; }
            public List<System.String> ResourceArns { get; set; }
            public System.String ResourceHandlingOption { get; set; }
            public System.String ResourceOwner { get; set; }
            public System.String ResourcePolicy { get; set; }
        }
        
    }
}
