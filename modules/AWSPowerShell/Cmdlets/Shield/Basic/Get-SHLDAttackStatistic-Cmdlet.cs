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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Provides information about the number and type of attacks AWS Shield has detected
    /// in the last year for all resources that belong to your account, regardless of whether
    /// you've defined Shield protections for them. This operation is available to Shield
    /// customers as well as to Shield Advanced customers.
    /// 
    ///  
    /// <para>
    /// The operation returns data for the time range of midnight UTC, one year ago, to midnight
    /// UTC, today. For example, if the current time is <code>2020-10-26 15:39:32 PDT</code>,
    /// equal to <code>2020-10-26 22:39:32 UTC</code>, then the time range for the attack
    /// data returned is from <code>2019-10-26 00:00:00 UTC</code> to <code>2020-10-26 00:00:00
    /// UTC</code>. 
    /// </para><para>
    /// The time range indicates the period covered by the attack statistics data items.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SHLDAttackStatistic")]
    [OutputType("Amazon.Shield.Model.DescribeAttackStatisticsResponse")]
    [AWSCmdlet("Calls the AWS Shield DescribeAttackStatistics API operation.", Operation = new[] {"DescribeAttackStatistics"}, SelectReturnType = typeof(Amazon.Shield.Model.DescribeAttackStatisticsResponse))]
    [AWSCmdletOutput("Amazon.Shield.Model.DescribeAttackStatisticsResponse",
        "This cmdlet returns an Amazon.Shield.Model.DescribeAttackStatisticsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSHLDAttackStatisticCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.DescribeAttackStatisticsResponse).
        /// Specifying the name of a property of type Amazon.Shield.Model.DescribeAttackStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.DescribeAttackStatisticsResponse, GetSHLDAttackStatisticCmdlet>(Select) ??
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
            var request = new Amazon.Shield.Model.DescribeAttackStatisticsRequest();
            
            
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
        
        private Amazon.Shield.Model.DescribeAttackStatisticsResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.DescribeAttackStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "DescribeAttackStatistics");
            try
            {
                #if DESKTOP
                return client.DescribeAttackStatistics(request);
                #elif CORECLR
                return client.DescribeAttackStatisticsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Shield.Model.DescribeAttackStatisticsResponse, GetSHLDAttackStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
