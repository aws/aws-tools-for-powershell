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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Allows you to purchase reserved nodes. Amazon Redshift offers a predefined set of
    /// reserved node offerings. You can purchase one or more of the offerings. You can call
    /// the <a>DescribeReservedNodeOfferings</a> API to obtain the available reserved node
    /// offerings. You can call this API by providing a specific reserved node offering and
    /// the number of nodes you want to reserve. 
    /// 
    ///  
    /// <para>
    ///  For more information about reserved node offerings, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/purchase-reserved-node-instance.html">Purchasing
    /// Reserved Nodes</a> in the <i>Amazon Redshift Cluster Management Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Request", "RSReservedNodeOffering", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ReservedNode")]
    [AWSCmdlet("Invokes the PurchaseReservedNodeOffering operation against Amazon Redshift.", Operation = new[] {"PurchaseReservedNodeOffering"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.ReservedNode",
        "This cmdlet returns a ReservedNode object.",
        "The service call response (type Amazon.Redshift.Model.PurchaseReservedNodeOfferingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RequestRSReservedNodeOfferingCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter NodeCount
        /// <summary>
        /// <para>
        /// <para>The number of reserved nodes that you want to purchase.</para><para>Default: <code>1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 NodeCount { get; set; }
        #endregion
        
        #region Parameter ReservedNodeOfferingId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the reserved node offering you want to purchase.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReservedNodeOfferingId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReservedNodeOfferingId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-RSReservedNodeOffering (PurchaseReservedNodeOffering)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("NodeCount"))
                context.NodeCount = this.NodeCount;
            context.ReservedNodeOfferingId = this.ReservedNodeOfferingId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Redshift.Model.PurchaseReservedNodeOfferingRequest();
            
            if (cmdletContext.NodeCount != null)
            {
                request.NodeCount = cmdletContext.NodeCount.Value;
            }
            if (cmdletContext.ReservedNodeOfferingId != null)
            {
                request.ReservedNodeOfferingId = cmdletContext.ReservedNodeOfferingId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PurchaseReservedNodeOffering(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReservedNode;
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
            public System.Int32? NodeCount { get; set; }
            public System.String ReservedNodeOfferingId { get; set; }
        }
        
    }
}
