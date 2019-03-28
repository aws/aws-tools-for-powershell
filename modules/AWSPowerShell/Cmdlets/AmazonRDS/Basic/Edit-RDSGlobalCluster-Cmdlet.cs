/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modify a setting for an Amazon Aurora global cluster. You can change one or more
    /// database configuration parameters by specifying these parameters and the new values
    /// in the request. For more information on Amazon Aurora, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What Is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide.</i><note><para>
    /// This action only applies to Aurora DB clusters.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "RDSGlobalCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.GlobalCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyGlobalCluster API operation.", Operation = new[] {"ModifyGlobalCluster"})]
    [AWSCmdletOutput("Amazon.RDS.Model.GlobalCluster",
        "This cmdlet returns a GlobalCluster object.",
        "The service call response (type Amazon.RDS.Model.ModifyGlobalClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRDSGlobalClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para> Indicates if the global database cluster has deletion protection enabled. The global
        /// database cluster can't be deleted when this value is set to true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DeletionProtection { get; set; }
        #endregion
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para> The DB cluster identifier for the global cluster being modified. This parameter is
        /// not case-sensitive. </para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing global database cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String GlobalClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter NewGlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para> The new cluster identifier for the global database cluster when modifying a global
        /// database cluster. This value is stored as a lowercase string. </para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens</para></li><li><para>The first character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul><para>Example: <code>my-cluster2</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewGlobalClusterIdentifier { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GlobalClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSGlobalCluster (ModifyGlobalCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("DeletionProtection"))
                context.DeletionProtection = this.DeletionProtection;
            context.GlobalClusterIdentifier = this.GlobalClusterIdentifier;
            context.NewGlobalClusterIdentifier = this.NewGlobalClusterIdentifier;
            
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
            var request = new Amazon.RDS.Model.ModifyGlobalClusterRequest();
            
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.GlobalClusterIdentifier != null)
            {
                request.GlobalClusterIdentifier = cmdletContext.GlobalClusterIdentifier;
            }
            if (cmdletContext.NewGlobalClusterIdentifier != null)
            {
                request.NewGlobalClusterIdentifier = cmdletContext.NewGlobalClusterIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GlobalCluster;
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
        
        #region AWS Service Operation Call
        
        private Amazon.RDS.Model.ModifyGlobalClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyGlobalClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyGlobalCluster");
            try
            {
                #if DESKTOP
                return client.ModifyGlobalCluster(request);
                #elif CORECLR
                return client.ModifyGlobalClusterAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeletionProtection { get; set; }
            public System.String GlobalClusterIdentifier { get; set; }
            public System.String NewGlobalClusterIdentifier { get; set; }
        }
        
    }
}
