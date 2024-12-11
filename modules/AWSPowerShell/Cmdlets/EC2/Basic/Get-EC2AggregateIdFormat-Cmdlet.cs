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
    /// Describes the longer ID format settings for all resource types in a specific Region.
    /// This request is useful for performing a quick audit to determine whether a specific
    /// Region is fully opted in for longer IDs (17-character IDs).
    /// 
    ///  
    /// <para>
    /// This request only returns information about resource types that support longer IDs.
    /// </para><para>
    /// The following resource types support longer IDs: <c>bundle</c> | <c>conversion-task</c>
    /// | <c>customer-gateway</c> | <c>dhcp-options</c> | <c>elastic-ip-allocation</c> | <c>elastic-ip-association</c>
    /// | <c>export-task</c> | <c>flow-log</c> | <c>image</c> | <c>import-task</c> | <c>instance</c>
    /// | <c>internet-gateway</c> | <c>network-acl</c> | <c>network-acl-association</c> |
    /// <c>network-interface</c> | <c>network-interface-attachment</c> | <c>prefix-list</c>
    /// | <c>reservation</c> | <c>route-table</c> | <c>route-table-association</c> | <c>security-group</c>
    /// | <c>snapshot</c> | <c>subnet</c> | <c>subnet-cidr-block-association</c> | <c>volume</c>
    /// | <c>vpc</c> | <c>vpc-cidr-block-association</c> | <c>vpc-endpoint</c> | <c>vpc-peering-connection</c>
    /// | <c>vpn-connection</c> | <c>vpn-gateway</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2AggregateIdFormat")]
    [OutputType("Amazon.EC2.Model.DescribeAggregateIdFormatResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeAggregateIdFormat API operation.", Operation = new[] {"DescribeAggregateIdFormat"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeAggregateIdFormatResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.DescribeAggregateIdFormatResponse",
        "This cmdlet returns an Amazon.EC2.Model.DescribeAggregateIdFormatResponse object containing multiple properties."
    )]
    public partial class GetEC2AggregateIdFormatCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeAggregateIdFormatResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeAggregateIdFormatResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeAggregateIdFormatResponse, GetEC2AggregateIdFormatCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.EC2.Model.DescribeAggregateIdFormatRequest();
            
            
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
        
        private Amazon.EC2.Model.DescribeAggregateIdFormatResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeAggregateIdFormatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeAggregateIdFormat");
            try
            {
                #if DESKTOP
                return client.DescribeAggregateIdFormat(request);
                #elif CORECLR
                return client.DescribeAggregateIdFormatAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.EC2.Model.DescribeAggregateIdFormatResponse, GetEC2AggregateIdFormatCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
