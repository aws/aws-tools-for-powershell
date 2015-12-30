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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Indicates whether the specified AWS resources are compliant. If a resource is noncompliant,
    /// this action returns the number of AWS Config rules that the resource does not comply
    /// with. 
    /// 
    ///  
    /// <para>
    /// A resource is compliant if it complies with all the AWS Config rules that evaluate
    /// it. It is noncompliant if it does not comply with one or more of these rules.
    /// </para><para>
    /// If AWS Config has no current evaluation results for the resource, it returns <code>InsufficientData</code>.
    /// This result might indicate one of the following conditions about the rules that evaluate
    /// the resource: <ul><li>AWS Config has never invoked an evaluation for the rule. To
    /// check whether it has, use the <code>DescribeConfigRuleEvaluationStatus</code> action
    /// to get the <code>LastSuccessfulInvocationTime</code> and <code>LastFailedInvocationTime</code>.</li><li>The rule's AWS Lambda function is failing to send evaluation results to AWS Config.
    /// Verify that the role that you assigned to your configuration recorder includes the
    /// <code>config:PutEvaluations</code> permission. If the rule is a customer managed rule,
    /// verify that the AWS Lambda execution role includes the <code>config:PutEvaluations</code>
    /// permission.</li><li>The rule's AWS Lambda function has returned <code>NOT_APPLICABLE</code>
    /// for all evaluation results. This can occur if the resources were deleted or removed
    /// from the rule's scope.</li></ul></para>
    /// </summary>
    [Cmdlet("Get", "CFGComplianceByResource")]
    [OutputType("Amazon.ConfigService.Model.ComplianceByResource")]
    [AWSCmdlet("Invokes the DescribeComplianceByResource operation against AWS Config.", Operation = new[] {"DescribeComplianceByResource"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ComplianceByResource",
        "This cmdlet returns a collection of ComplianceByResource objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeComplianceByResourceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetCFGComplianceByResourceCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ComplianceType
        /// <summary>
        /// <para>
        /// <para>Filters the results by compliance. The valid values are <code>Compliant</code> and
        /// <code>NonCompliant</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComplianceTypes")]
        public System.String[] ComplianceType { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS resource for which you want compliance information. You can specify
        /// only one resource ID. If you specify a resource ID, you must also specify a type for
        /// <code>ResourceType</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The types of AWS resources for which you want compliance information; for example,
        /// <code>AWS::EC2::Instance</code>. For this action, you can specify that the resource
        /// type is an AWS account by specifying <code>AWS::::Account</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of evaluation results returned on each page. The default is 10.
        /// You cannot specify a limit greater than 100. If you specify 0, AWS Config uses the
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response.</para>
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
            
            if (this.ComplianceType != null)
            {
                context.ComplianceTypes = new List<System.String>(this.ComplianceType);
            }
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            context.ResourceId = this.ResourceId;
            context.ResourceType = this.ResourceType;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ConfigService.Model.DescribeComplianceByResourceRequest();
            
            if (cmdletContext.ComplianceTypes != null)
            {
                request.ComplianceTypes = cmdletContext.ComplianceTypes;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeComplianceByResource(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ComplianceByResources;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> ComplianceTypes { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceId { get; set; }
            public System.String ResourceType { get; set; }
        }
        
    }
}
