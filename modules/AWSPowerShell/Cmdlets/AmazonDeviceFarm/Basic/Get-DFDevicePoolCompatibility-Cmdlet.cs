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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Gets information about compatibility with a device pool.
    /// </summary>
    [Cmdlet("Get", "DFDevicePoolCompatibility")]
    [OutputType("Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse")]
    [AWSCmdlet("Invokes the GetDevicePoolCompatibility operation against AWS Device Farm.", Operation = new[] {"GetDevicePoolCompatibility"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse",
        "This cmdlet returns a Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDFDevicePoolCompatibilityCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the app that is associated with the specified device pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AppArn { get; set; }
        #endregion
        
        #region Parameter DevicePoolArn
        /// <summary>
        /// <para>
        /// <para>The device pool's ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DevicePoolArn { get; set; }
        #endregion
        
        #region Parameter TestType
        /// <summary>
        /// <para>
        /// <para>The test type for the specified device pool.</para><para>Allowed values include the following:</para><ul><li><para>BUILTIN_FUZZ: The built-in fuzz type.</para></li><li><para>BUILTIN_EXPLORER: For Android, an app explorer that will traverse an Android app,
        /// interacting with it and capturing screenshots at the same time.</para></li><li><para>APPIUM_JAVA_JUNIT: The Appium Java JUnit type.</para></li><li><para>APPIUM_JAVA_TESTNG: The Appium Java TestNG type.</para></li><li><para>APPIUM_PYTHON: The Appium Python type.</para></li><li><para>APPIUM_WEB_JAVA_JUNIT: The Appium Java JUnit type for Web apps.</para></li><li><para>APPIUM_WEB_JAVA_TESTNG: The Appium Java TestNG type for Web apps.</para></li><li><para>APPIUM_WEB_PYTHON: The Appium Python type for Web apps.</para></li><li><para>CALABASH: The Calabash type.</para></li><li><para>INSTRUMENTATION: The Instrumentation type.</para></li><li><para>UIAUTOMATION: The uiautomation type.</para></li><li><para>UIAUTOMATOR: The uiautomator type.</para></li><li><para>XCTEST: The XCode test type.</para></li><li><para>XCTEST_UI: The XCode UI test type.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DeviceFarm.TestType")]
        public Amazon.DeviceFarm.TestType TestType { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AppArn = this.AppArn;
            context.DevicePoolArn = this.DevicePoolArn;
            context.TestType = this.TestType;
            
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
            var request = new Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            if (cmdletContext.DevicePoolArn != null)
            {
                request.DevicePoolArn = cmdletContext.DevicePoolArn;
            }
            if (cmdletContext.TestType != null)
            {
                request.TestType = cmdletContext.TestType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private static Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityRequest request)
        {
            #if DESKTOP
            return client.GetDevicePoolCompatibility(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetDevicePoolCompatibilityAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AppArn { get; set; }
            public System.String DevicePoolArn { get; set; }
            public Amazon.DeviceFarm.TestType TestType { get; set; }
        }
        
    }
}
