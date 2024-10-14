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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Returns a list of all CloudWatch Logs account policies in the account.
    /// </summary>
    [Cmdlet("Get", "CWLAccountPolicy")]
    [OutputType("Amazon.CloudWatchLogs.Model.AccountPolicy")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs DescribeAccountPolicies API operation.", Operation = new[] {"DescribeAccountPolicies"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.DescribeAccountPoliciesResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.AccountPolicy or Amazon.CloudWatchLogs.Model.DescribeAccountPoliciesResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchLogs.Model.AccountPolicy objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.DescribeAccountPoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWLAccountPolicyCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountIdentifier
        /// <summary>
        /// <para>
        /// <para>If you are using an account that is set up as a monitoring account for CloudWatch
        /// unified cross-account observability, you can use this to specify the account ID of
        /// a source account. If you do, the operation returns the account policy for the specified
        /// account. Currently, you can specify only one account ID in this parameter.</para><para>If you omit this parameter, only the policy in the current account is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIdentifiers")]
        public System.String[] AccountIdentifier { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>Use this parameter to limit the returned policies to only the policy with the name
        /// that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>Use this parameter to limit the returned policies to only the policies that match
        /// the policy type that you specify.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.PolicyType")]
        public Amazon.CloudWatchLogs.PolicyType PolicyType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountPolicies'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.DescribeAccountPoliciesResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.DescribeAccountPoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountPolicies";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PolicyType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PolicyType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PolicyType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.DescribeAccountPoliciesResponse, GetCWLAccountPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PolicyType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccountIdentifier != null)
            {
                context.AccountIdentifier = new List<System.String>(this.AccountIdentifier);
            }
            context.PolicyName = this.PolicyName;
            context.PolicyType = this.PolicyType;
            #if MODULAR
            if (this.PolicyType == null && ParameterWasBound(nameof(this.PolicyType)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudWatchLogs.Model.DescribeAccountPoliciesRequest();
            
            if (cmdletContext.AccountIdentifier != null)
            {
                request.AccountIdentifiers = cmdletContext.AccountIdentifier;
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            if (cmdletContext.PolicyType != null)
            {
                request.PolicyType = cmdletContext.PolicyType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        #region AWS Service Operation Call
        
        private Amazon.CloudWatchLogs.Model.DescribeAccountPoliciesResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.DescribeAccountPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "DescribeAccountPolicies");
            try
            {
                #if DESKTOP
                return client.DescribeAccountPolicies(request);
                #elif CORECLR
                return client.DescribeAccountPoliciesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountIdentifier { get; set; }
            public System.String PolicyName { get; set; }
            public Amazon.CloudWatchLogs.PolicyType PolicyType { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.DescribeAccountPoliciesResponse, GetCWLAccountPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountPolicies;
        }
        
    }
}
