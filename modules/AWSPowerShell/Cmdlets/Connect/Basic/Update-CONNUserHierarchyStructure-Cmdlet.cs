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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates the user hierarchy structure: add, remove, and rename user hierarchy levels.
    /// </summary>
    [Cmdlet("Update", "CONNUserHierarchyStructure", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateUserHierarchyStructure API operation.", Operation = new[] {"UpdateUserHierarchyStructure"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateUserHierarchyStructureResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateUserHierarchyStructureResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateUserHierarchyStructureResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNUserHierarchyStructureCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter LevelFive_Name
        /// <summary>
        /// <para>
        /// <para>The name of the user hierarchy level. Must not be more than 50 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HierarchyStructure_LevelFive_Name")]
        public System.String LevelFive_Name { get; set; }
        #endregion
        
        #region Parameter LevelFour_Name
        /// <summary>
        /// <para>
        /// <para>The name of the user hierarchy level. Must not be more than 50 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HierarchyStructure_LevelFour_Name")]
        public System.String LevelFour_Name { get; set; }
        #endregion
        
        #region Parameter LevelOne_Name
        /// <summary>
        /// <para>
        /// <para>The name of the user hierarchy level. Must not be more than 50 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HierarchyStructure_LevelOne_Name")]
        public System.String LevelOne_Name { get; set; }
        #endregion
        
        #region Parameter LevelThree_Name
        /// <summary>
        /// <para>
        /// <para>The name of the user hierarchy level. Must not be more than 50 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HierarchyStructure_LevelThree_Name")]
        public System.String LevelThree_Name { get; set; }
        #endregion
        
        #region Parameter LevelTwo_Name
        /// <summary>
        /// <para>
        /// <para>The name of the user hierarchy level. Must not be more than 50 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HierarchyStructure_LevelTwo_Name")]
        public System.String LevelTwo_Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateUserHierarchyStructureResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNUserHierarchyStructure (UpdateUserHierarchyStructure)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateUserHierarchyStructureResponse, UpdateCONNUserHierarchyStructureCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LevelFive_Name = this.LevelFive_Name;
            context.LevelFour_Name = this.LevelFour_Name;
            context.LevelOne_Name = this.LevelOne_Name;
            context.LevelThree_Name = this.LevelThree_Name;
            context.LevelTwo_Name = this.LevelTwo_Name;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateUserHierarchyStructureRequest();
            
            
             // populate HierarchyStructure
            var requestHierarchyStructureIsNull = true;
            request.HierarchyStructure = new Amazon.Connect.Model.HierarchyStructureUpdate();
            Amazon.Connect.Model.HierarchyLevelUpdate requestHierarchyStructure_hierarchyStructure_LevelFive = null;
            
             // populate LevelFive
            var requestHierarchyStructure_hierarchyStructure_LevelFiveIsNull = true;
            requestHierarchyStructure_hierarchyStructure_LevelFive = new Amazon.Connect.Model.HierarchyLevelUpdate();
            System.String requestHierarchyStructure_hierarchyStructure_LevelFive_levelFive_Name = null;
            if (cmdletContext.LevelFive_Name != null)
            {
                requestHierarchyStructure_hierarchyStructure_LevelFive_levelFive_Name = cmdletContext.LevelFive_Name;
            }
            if (requestHierarchyStructure_hierarchyStructure_LevelFive_levelFive_Name != null)
            {
                requestHierarchyStructure_hierarchyStructure_LevelFive.Name = requestHierarchyStructure_hierarchyStructure_LevelFive_levelFive_Name;
                requestHierarchyStructure_hierarchyStructure_LevelFiveIsNull = false;
            }
             // determine if requestHierarchyStructure_hierarchyStructure_LevelFive should be set to null
            if (requestHierarchyStructure_hierarchyStructure_LevelFiveIsNull)
            {
                requestHierarchyStructure_hierarchyStructure_LevelFive = null;
            }
            if (requestHierarchyStructure_hierarchyStructure_LevelFive != null)
            {
                request.HierarchyStructure.LevelFive = requestHierarchyStructure_hierarchyStructure_LevelFive;
                requestHierarchyStructureIsNull = false;
            }
            Amazon.Connect.Model.HierarchyLevelUpdate requestHierarchyStructure_hierarchyStructure_LevelFour = null;
            
             // populate LevelFour
            var requestHierarchyStructure_hierarchyStructure_LevelFourIsNull = true;
            requestHierarchyStructure_hierarchyStructure_LevelFour = new Amazon.Connect.Model.HierarchyLevelUpdate();
            System.String requestHierarchyStructure_hierarchyStructure_LevelFour_levelFour_Name = null;
            if (cmdletContext.LevelFour_Name != null)
            {
                requestHierarchyStructure_hierarchyStructure_LevelFour_levelFour_Name = cmdletContext.LevelFour_Name;
            }
            if (requestHierarchyStructure_hierarchyStructure_LevelFour_levelFour_Name != null)
            {
                requestHierarchyStructure_hierarchyStructure_LevelFour.Name = requestHierarchyStructure_hierarchyStructure_LevelFour_levelFour_Name;
                requestHierarchyStructure_hierarchyStructure_LevelFourIsNull = false;
            }
             // determine if requestHierarchyStructure_hierarchyStructure_LevelFour should be set to null
            if (requestHierarchyStructure_hierarchyStructure_LevelFourIsNull)
            {
                requestHierarchyStructure_hierarchyStructure_LevelFour = null;
            }
            if (requestHierarchyStructure_hierarchyStructure_LevelFour != null)
            {
                request.HierarchyStructure.LevelFour = requestHierarchyStructure_hierarchyStructure_LevelFour;
                requestHierarchyStructureIsNull = false;
            }
            Amazon.Connect.Model.HierarchyLevelUpdate requestHierarchyStructure_hierarchyStructure_LevelOne = null;
            
             // populate LevelOne
            var requestHierarchyStructure_hierarchyStructure_LevelOneIsNull = true;
            requestHierarchyStructure_hierarchyStructure_LevelOne = new Amazon.Connect.Model.HierarchyLevelUpdate();
            System.String requestHierarchyStructure_hierarchyStructure_LevelOne_levelOne_Name = null;
            if (cmdletContext.LevelOne_Name != null)
            {
                requestHierarchyStructure_hierarchyStructure_LevelOne_levelOne_Name = cmdletContext.LevelOne_Name;
            }
            if (requestHierarchyStructure_hierarchyStructure_LevelOne_levelOne_Name != null)
            {
                requestHierarchyStructure_hierarchyStructure_LevelOne.Name = requestHierarchyStructure_hierarchyStructure_LevelOne_levelOne_Name;
                requestHierarchyStructure_hierarchyStructure_LevelOneIsNull = false;
            }
             // determine if requestHierarchyStructure_hierarchyStructure_LevelOne should be set to null
            if (requestHierarchyStructure_hierarchyStructure_LevelOneIsNull)
            {
                requestHierarchyStructure_hierarchyStructure_LevelOne = null;
            }
            if (requestHierarchyStructure_hierarchyStructure_LevelOne != null)
            {
                request.HierarchyStructure.LevelOne = requestHierarchyStructure_hierarchyStructure_LevelOne;
                requestHierarchyStructureIsNull = false;
            }
            Amazon.Connect.Model.HierarchyLevelUpdate requestHierarchyStructure_hierarchyStructure_LevelThree = null;
            
             // populate LevelThree
            var requestHierarchyStructure_hierarchyStructure_LevelThreeIsNull = true;
            requestHierarchyStructure_hierarchyStructure_LevelThree = new Amazon.Connect.Model.HierarchyLevelUpdate();
            System.String requestHierarchyStructure_hierarchyStructure_LevelThree_levelThree_Name = null;
            if (cmdletContext.LevelThree_Name != null)
            {
                requestHierarchyStructure_hierarchyStructure_LevelThree_levelThree_Name = cmdletContext.LevelThree_Name;
            }
            if (requestHierarchyStructure_hierarchyStructure_LevelThree_levelThree_Name != null)
            {
                requestHierarchyStructure_hierarchyStructure_LevelThree.Name = requestHierarchyStructure_hierarchyStructure_LevelThree_levelThree_Name;
                requestHierarchyStructure_hierarchyStructure_LevelThreeIsNull = false;
            }
             // determine if requestHierarchyStructure_hierarchyStructure_LevelThree should be set to null
            if (requestHierarchyStructure_hierarchyStructure_LevelThreeIsNull)
            {
                requestHierarchyStructure_hierarchyStructure_LevelThree = null;
            }
            if (requestHierarchyStructure_hierarchyStructure_LevelThree != null)
            {
                request.HierarchyStructure.LevelThree = requestHierarchyStructure_hierarchyStructure_LevelThree;
                requestHierarchyStructureIsNull = false;
            }
            Amazon.Connect.Model.HierarchyLevelUpdate requestHierarchyStructure_hierarchyStructure_LevelTwo = null;
            
             // populate LevelTwo
            var requestHierarchyStructure_hierarchyStructure_LevelTwoIsNull = true;
            requestHierarchyStructure_hierarchyStructure_LevelTwo = new Amazon.Connect.Model.HierarchyLevelUpdate();
            System.String requestHierarchyStructure_hierarchyStructure_LevelTwo_levelTwo_Name = null;
            if (cmdletContext.LevelTwo_Name != null)
            {
                requestHierarchyStructure_hierarchyStructure_LevelTwo_levelTwo_Name = cmdletContext.LevelTwo_Name;
            }
            if (requestHierarchyStructure_hierarchyStructure_LevelTwo_levelTwo_Name != null)
            {
                requestHierarchyStructure_hierarchyStructure_LevelTwo.Name = requestHierarchyStructure_hierarchyStructure_LevelTwo_levelTwo_Name;
                requestHierarchyStructure_hierarchyStructure_LevelTwoIsNull = false;
            }
             // determine if requestHierarchyStructure_hierarchyStructure_LevelTwo should be set to null
            if (requestHierarchyStructure_hierarchyStructure_LevelTwoIsNull)
            {
                requestHierarchyStructure_hierarchyStructure_LevelTwo = null;
            }
            if (requestHierarchyStructure_hierarchyStructure_LevelTwo != null)
            {
                request.HierarchyStructure.LevelTwo = requestHierarchyStructure_hierarchyStructure_LevelTwo;
                requestHierarchyStructureIsNull = false;
            }
             // determine if request.HierarchyStructure should be set to null
            if (requestHierarchyStructureIsNull)
            {
                request.HierarchyStructure = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.Connect.Model.UpdateUserHierarchyStructureResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateUserHierarchyStructureRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateUserHierarchyStructure");
            try
            {
                #if DESKTOP
                return client.UpdateUserHierarchyStructure(request);
                #elif CORECLR
                return client.UpdateUserHierarchyStructureAsync(request).GetAwaiter().GetResult();
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
            public System.String LevelFive_Name { get; set; }
            public System.String LevelFour_Name { get; set; }
            public System.String LevelOne_Name { get; set; }
            public System.String LevelThree_Name { get; set; }
            public System.String LevelTwo_Name { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateUserHierarchyStructureResponse, UpdateCONNUserHierarchyStructureCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
